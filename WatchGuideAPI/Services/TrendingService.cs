using Npgsql;
using WatchGuideAPI.Models;
using WatchGuideAPI.DTOs;

namespace WatchGuideAPI.Services
{
    public interface ITrendingService
    {
        Task<List<TrendingCache>> GetTrendingContent();
    }

    public class TrendingService : ITrendingService
    {
        private readonly string _connectionString;
        private readonly ITMDBService _tmdbService;
        private readonly ILogger<TrendingService> _logger;

        public TrendingService(
            IConfiguration configuration,
            ITMDBService tmdbService,
            ILogger<TrendingService> logger)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
            _tmdbService = tmdbService;
            _logger = logger;
        }

        public async Task<List<TrendingCache>> GetTrendingContent()
        {
            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();

            var cachedData = await GetCachedTrending(conn);

            if (cachedData.Any() && cachedData.First().ExpiresAt > DateTime.UtcNow)
            {
                _logger.LogInformation($"Returning {cachedData.Count} trending items from cache");
                return cachedData;
            }

            _logger.LogInformation("Cache expired or empty. Fetching fresh trending data from TMDB...");

            var freshData = await _tmdbService.GetWeeklyTrending();

            if (!freshData.Any())
            {
                _logger.LogWarning("TMDB returned no trending data");
                return cachedData;
            }

            await RefreshCache(conn, freshData);

            return await GetCachedTrending(conn);
        }

        private async Task<List<TrendingCache>> GetCachedTrending(NpgsqlConnection conn)
        {
            var sql = @"
                SELECT id, tmdb_id, title, media_type, poster_url, backdrop_url, 
                       rating, overview, release_date, genre_ids, language, trending_rank, 
                       cached_at, expires_at
                FROM trending_cache
                ORDER BY trending_rank ASC
                LIMIT 20";

            await using var cmd = new NpgsqlCommand(sql, conn);
            await using var reader = await cmd.ExecuteReaderAsync();

            var results = new List<TrendingCache>();

            while (await reader.ReadAsync())
            {
                results.Add(new TrendingCache
                {
                    Id = reader.GetInt32(0),
                    TmdbId = reader.GetInt32(1),
                    Title = reader.GetString(2),
                    MediaType = reader.GetString(3),
                    PosterUrl = reader.IsDBNull(4) ? null : reader.GetString(4),
                    BackdropUrl = reader.IsDBNull(5) ? null : reader.GetString(5),
                    Rating = reader.IsDBNull(6) ? null : reader.GetDecimal(6),
                    Overview = reader.IsDBNull(7) ? null : reader.GetString(7),
                    ReleaseDate = reader.IsDBNull(8) ? null : reader.GetDateTime(8),
                    GenreIds = reader.IsDBNull(9) ? null : (int[])reader.GetValue(9),
                    Language = reader.IsDBNull(10) ? null : reader.GetString(10),
                    TrendingRank = reader.GetInt32(11),
                    CachedAt = reader.GetDateTime(12),
                    ExpiresAt = reader.GetDateTime(13)
                });
            }

            return results;
        }

        private async Task RefreshCache(NpgsqlConnection conn, List<TMDBSearchResult> freshData)
        {
            await using var transaction = await conn.BeginTransactionAsync();

            try
            {
                var deleteSql = "DELETE FROM trending_cache";
                await using (var deleteCmd = new NpgsqlCommand(deleteSql, conn, transaction))
                {
                    await deleteCmd.ExecuteNonQueryAsync();
                }

                var insertSql = @"
                    INSERT INTO trending_cache 
                    (tmdb_id, title, media_type, poster_url, backdrop_url, rating, 
                     overview, release_date, genre_ids, language, trending_rank, expires_at)
                    VALUES 
                    (@tmdbId, @title, @mediaType, @posterUrl, @backdropUrl, @rating, 
                     @overview, @releaseDate, @genreIds, @language, @rank, @expiresAt)";

                var expiresAt = DateTime.UtcNow.AddDays(7);
                int rank = 1;

                foreach (var item in freshData.Take(20))
                {
                    await using var insertCmd = new NpgsqlCommand(insertSql, conn, transaction);

                    string title = item.MediaType == "tv" ? item.Name : item.Title;

                    string? posterUrl = !string.IsNullOrEmpty(item.PosterPath)
                        ? $"https://image.tmdb.org/t/p/w500{item.PosterPath}"
                        : null;

                    string? backdropUrl = !string.IsNullOrEmpty(item.BackdropPath)
                        ? $"https://image.tmdb.org/t/p/original{item.BackdropPath}"
                        : null;

                    DateTime? releaseDate = null;

                    var rawDate = item.MediaType == "tv"
                        ? item.FirstAirDate
                        : item.ReleaseDate;

                    if (!string.IsNullOrWhiteSpace(rawDate) &&
                        DateTime.TryParse(rawDate, out var parsedDate))
                    {
                        releaseDate = parsedDate;
                    }


                    insertCmd.Parameters.AddWithValue("tmdbId", item.Id);
                    insertCmd.Parameters.AddWithValue("title", title ?? "Unknown");
                    insertCmd.Parameters.AddWithValue("mediaType", item.MediaType ?? "tv");
                    insertCmd.Parameters.AddWithValue("posterUrl", (object?)posterUrl ?? DBNull.Value);
                    insertCmd.Parameters.AddWithValue("backdropUrl", (object?)backdropUrl ?? DBNull.Value);
                    insertCmd.Parameters.AddWithValue("rating", item.VoteAverage.HasValue ? (object)(decimal)item.VoteAverage.Value : DBNull.Value);
                    insertCmd.Parameters.AddWithValue("overview", (object?)item.Overview ?? DBNull.Value);
                    insertCmd.Parameters.AddWithValue("releaseDate", releaseDate.HasValue ? (object)releaseDate.Value : DBNull.Value);
                    insertCmd.Parameters.AddWithValue("genreIds", item.GenreIds?.ToArray() ?? Array.Empty<int>());
                    insertCmd.Parameters.AddWithValue("language",item.OriginalLanguage ?? (object)DBNull.Value);
                    insertCmd.Parameters.AddWithValue("rank", rank++);
                    insertCmd.Parameters.AddWithValue("expiresAt", expiresAt);

                    await insertCmd.ExecuteNonQueryAsync();
                }

                await transaction.CommitAsync();
                _logger.LogInformation($"Successfully cached {rank - 1} trending items (expires: {expiresAt})");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError($"Failed to refresh trending cache: {ex.Message}");
                throw;
            }
        }
    }
}