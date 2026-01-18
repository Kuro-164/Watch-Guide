using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchGuideAPI.Data;
using WatchGuideAPI.DTOs;
using WatchGuideAPI.Models;
using WatchGuideAPI.Services;

namespace WatchGuideAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContentController : ControllerBase
    {
        // ===== TMDB MAPPINGS =====
        private static readonly Dictionary<string, int> GenreMap = new()
        {
            { "Action", 28 }, { "Adventure", 12 }, { "Animation", 16 },
            { "Comedy", 35 }, { "Crime", 80 }, { "Drama", 18 },
            { "Fantasy", 14 }, { "Horror", 27 }, { "Romance", 10749 },
            { "Sci-Fi", 878 }, { "Thriller", 53 }
        };

        private static readonly Dictionary<string, string> LanguageMap = new()
        {
            { "English", "en" }, { "Hindi", "hi" }, { "Tamil", "ta" },
            { "Telugu", "te" }, { "Malayalam", "ml" }, { "Kannada", "kn" },
            { "Japanese", "ja" }, { "Korean", "ko" }
        };

        private readonly ITMDBService _tmdbService;
        private readonly ITrendingService _trendingService;
        private readonly IWatchmodeService _watchmodeService;
        private readonly AppDbContext _context;

        public ContentController(
            ITMDBService tmdbService,
            ITrendingService trendingService,
            IWatchmodeService watchmodeService,
            AppDbContext context)
        {
            _tmdbService = tmdbService;
            _trendingService = trendingService;
            _watchmodeService = watchmodeService;
            _context = context;
        }

        // ================= SEARCH =================
        [HttpGet("search")]
        public async Task<IActionResult> Search(string query, Guid? userId = null)
        {
            if (!string.IsNullOrWhiteSpace(query) && userId.HasValue)
            {
                await SaveSearchHistory(userId.Value, query);
            }

            var tmdbResults = await _tmdbService.SearchContent(query);

            var results = tmdbResults.Select(t => new ContentCardDto
            {
                TmdbId = t.Id,
                Title = t.Title ?? t.Name, 
                MediaType = t.MediaType, 
                PosterUrl = t.PosterPath 
            });

            return Ok(results);
        }

        // ================= SEARCH HISTORY =================
        [HttpGet("search/history/{userId}")]
        public async Task<IActionResult> GetSearchHistory(Guid userId)
        {
            var history = await _context.SearchHistories
                .Where(s => s.UserId == userId)
                .OrderByDescending(s => s.SearchedAt)
                .Select(s => new { s.Keyword, s.SearchedAt })
                .ToListAsync();

            return Ok(history);
        }

        // ================= DETAILS =================
        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetDetails(int id, string mediaType = "tv")
        {
            var details = await _tmdbService.GetContentDetails(id, mediaType);

            details.Cast = await _tmdbService.GetCast(id, mediaType);
            details.StreamingPlatforms = await _watchmodeService.GetStreamingSources(id, mediaType);

            return Ok(details);
        }

        // ================= TRENDING =================
        [HttpGet("trending")]
        public async Task<IActionResult> GetTrending()
        {
            var trending = await _trendingService.GetTrendingContent();

            return Ok(new
            {
                data = trending,
                cached = trending.FirstOrDefault()?.CachedAt,
                expires = trending.FirstOrDefault()?.ExpiresAt,
                count = trending.Count
            });
        }

        // ================= RECOMMENDATIONS =================
        [HttpGet("recommendations/{userId}")]
        public async Task<IActionResult> GetRecommendations(Guid userId)
        {
            var genreIds = await GetUserGenreIds(userId);
            var languageCodes = await GetUserLanguageCodes(userId);

            var trending = await _context.TrendingCaches.ToListAsync();

            if (genreIds.Any())
                trending = trending.Where(t =>
                    t.GenreIds != null && t.GenreIds.Any(g => genreIds.Contains(g))
                ).ToList();

            if (languageCodes.Any())
                trending = trending.Where(t =>
                    languageCodes.Contains(t.Language)
                ).ToList();

            var result = trending
                .OrderBy(t => t.TrendingRank)
                .Take(20)
                .Select(t => new ContentCardDto
                {
                    TmdbId = t.TmdbId,
                    Title = t.Title,
                    PosterUrl = t.PosterUrl ?? "",
                    MediaType = t.MediaType
                })
                .ToList();

            return Ok(result);
        }

        // ================= HELPER METHODS =================
        private async Task SaveSearchHistory(Guid userId, string query)
        {
            var cutoff = DateTime.UtcNow.AddDays(-7);

            await _context.SearchHistories
                .Where(s => s.SearchedAt < cutoff)
                .ExecuteDeleteAsync();

            var existing = await _context.SearchHistories
                .FirstOrDefaultAsync(s =>
                    s.UserId == userId &&
                    s.Keyword.ToLower() == query.ToLower());

            if (existing != null)
                existing.SearchedAt = DateTime.UtcNow;
            else
                _context.SearchHistories.Add(new SearchHistory
                {
                    UserId = userId,
                    Keyword = query
                });

            await _context.SaveChangesAsync();
        }

        private async Task<List<int>> GetUserGenreIds(Guid userId)
        {
            var genres = await _context.UserGenrePreferences
                .Where(g => g.UserId == userId)
                .Select(g => g.Genre)
                .ToListAsync();

            return genres
                .Where(g => GenreMap.ContainsKey(g))
                .Select(g => GenreMap[g])
                .ToList();
        }

        private async Task<List<string>> GetUserLanguageCodes(Guid userId)
        {
            var languages = await _context.UserLanguagePreferences
                .Where(l => l.UserId == userId)
                .Select(l => l.Language)
                .ToListAsync();

            return languages
                .Where(l => LanguageMap.ContainsKey(l))
                .Select(l => LanguageMap[l])
                .ToList();
        }
    }
}
