using System.Text.Json;
using WatchGuideAPI.DTOs;
using static System.Net.WebRequestMethods;

namespace WatchGuideAPI.Services
{
    public interface ITMDBService
    {
        Task<List<TMDBSearchResult>> SearchContent(string query);
        Task<ContentDetailsResponse> GetContentDetails(int tmdbId, string mediaType);
        Task<List<TMDBSearchResult>> GetWeeklyTrending();
        Task<List<CastDto>> GetCast(int tmdbId, string mediaType);

    }

    public class TMDBService : ITMDBService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _baseUrl;
        private readonly IWatchmodeService _watchmodeService;

        public TMDBService(IConfiguration configuration, HttpClient httpClient, IWatchmodeService watchmodeService)
        {
            _httpClient = httpClient;
            _apiKey = configuration["APIs:TMDB:ApiKey"];
            _baseUrl = configuration["APIs:TMDB:BaseUrl"];
            _watchmodeService = watchmodeService;
        }

        public async Task<List<TMDBSearchResult>> SearchContent(string query)
        {
            try
            {
                string url = $"{_baseUrl}/search/multi?api_key={_apiKey}&query={Uri.EscapeDataString(query)}";

                Console.WriteLine($"Calling TMDB: {url}");

                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"TMDB Response: {content}");

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
                };

                var result = JsonSerializer.Deserialize<SearchResponse>(content, options);

                var filteredResults = result?.Results?
                    .Where(r => r.MediaType == "movie" || r.MediaType == "tv")
                    .ToList() ?? new List<TMDBSearchResult>();

                Console.WriteLine($"Filtered results count: {filteredResults.Count}");

                return filteredResults;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"TMDB Error: {ex.Message}");
                throw new Exception($"TMDB search failed: {ex.Message}");
            }
        }

        public async Task<ContentDetailsResponse> GetContentDetails(int tmdbId, string mediaType)
        {
            try
            {
                string endpoint = mediaType == "movie" ? "movie" : "tv";
                string url = $"{_baseUrl}/{endpoint}/{tmdbId}?api_key={_apiKey}&language=en-US";

                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var jsonDoc = JsonDocument.Parse(content);
                var root = jsonDoc.RootElement;

                var details = new ContentDetailsResponse
                {
                    TmdbId = tmdbId,
                    Title = mediaType == "movie"
                        ? root.GetProperty("title").GetString()
                        : root.GetProperty("name").GetString(),
                    Type = mediaType,
                    Description = root.GetProperty("overview").GetString(),
                    Language = root.TryGetProperty("original_language", out var lang)
                        ? lang.GetString()
                        : null,
                    PosterUrl = root.TryGetProperty("poster_path", out var poster) && !poster.ValueKind.Equals(JsonValueKind.Null)
                        ? $"https://image.tmdb.org/t/p/w500{poster.GetString()}"
                        : null,
                    BackdropUrl = root.TryGetProperty("backdrop_path", out var backdrop) && !backdrop.ValueKind.Equals(JsonValueKind.Null)
                        ? $"https://image.tmdb.org/t/p/original{backdrop.GetString()}"
                        : null,
                    Rating = root.TryGetProperty("vote_average", out var rating)
                        ? (float)rating.GetDouble()
                        : 0f,
                    Genres = root.TryGetProperty("genres", out var genres)
                        ? genres.EnumerateArray()
                            .Select(g => g.GetProperty("name").GetString())
                            .ToList()
                        : new List<string>()
                };
                return details;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get content details: {ex.Message}");
            }
        }

        public async Task<List<TMDBSearchResult>> GetWeeklyTrending()
        {
            try
            {
                string url = $"{_baseUrl}/trending/all/week?api_key={_apiKey}&language=en-US";

                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
                };

                var result = JsonSerializer.Deserialize<SearchResponse>(content, options);

                return result?.Results?
                    .Where(r => r.MediaType == "movie" || r.MediaType == "tv")
                    .ToList()
                    ?? new List<TMDBSearchResult>();
            }
            catch (Exception ex)
            {
                throw new Exception($"TMDB trending failed: {ex.Message}");
            }
        }

        public async Task<List<CastDto>> GetCast(int tmdbId, string mediaType)
        {
            var url = $"https://api.themoviedb.org/3/{mediaType}/{tmdbId}/credits?api_key={_apiKey}";

            var response = await _httpClient.GetStringAsync(url);
            var data = JsonSerializer.Deserialize<TmdbCreditsDto>(response);

            return data.Cast
                .Where(c => c.ProfilePath != null)
                .Take(12)
                .Select(c => new CastDto
                {
                    Name = c.Name,
                    Character = c.Character,
                    Photo = "https://image.tmdb.org/t/p/w200" + c.ProfilePath
                })
                .ToList();
        }

    }
}