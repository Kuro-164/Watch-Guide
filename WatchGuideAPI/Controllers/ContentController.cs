using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchGuideAPI.Data;
using WatchGuideAPI.DTOs;
using WatchGuideAPI.Models;
using WatchGuideAPI.Services;

namespace WatchGuideAPI.Controllers
{
    // Controllers/ContentController.cs

    [ApiController]
    [Route("api/[controller]")]
    public class ContentController : ControllerBase
    {
        private static readonly Dictionary<string, int> TmdbGenreMap = new()
        {
            { "Action", 28 },
            { "Adventure", 12 },
            { "Animation", 16 },
            { "Comedy", 35 },
            { "Crime", 80 },
            { "Drama", 18 },
            { "Fantasy", 14 },
            { "Horror", 27 },
            { "Romance", 10749 },
            { "Sci-Fi", 878 },
            { "Thriller", 53 }
         };
        private static readonly Dictionary<string, string> TmdbLanguageMap = new()
        {
            { "English", "en" },
            { "Hindi", "hi" },
            { "Tamil", "ta" },
            { "Telugu", "te" },
            { "Malayalam", "ml" },
            { "Kannada", "kn" },
            { "Japanese", "ja" },
            { "Korean", "ko" }
        };
        private readonly ITMDBService _tmdbService;
        private readonly ITrendingService _trendingService; // NEW
        private readonly IWatchmodeService _watchmodeService;
        private readonly IContentService _contentService;
        private readonly AppDbContext _context;

        public ContentController(ITMDBService tmdbService, ITrendingService trendingService, IWatchmodeService watchmodeService, IContentService contentService, AppDbContext context)
        {
            _tmdbService = tmdbService;
            _trendingService = trendingService;
            _watchmodeService = watchmodeService;
            _contentService = contentService;
            _context = context;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(
    string query,
    [FromQuery] Guid? userId = null)
        {
            if (!string.IsNullOrWhiteSpace(query) && userId.HasValue)
            {
                // 🧹 Auto-cleanup: delete searches older than 7 days
                var cutoffDate = DateTime.UtcNow.AddDays(-7);

                await _context.SearchHistories
                    .Where(s => s.SearchedAt < cutoffDate)
                    .ExecuteDeleteAsync();

                // 🔁 Prevent duplicate keyword per user
                var existingSearch = await _context.SearchHistories
                    .FirstOrDefaultAsync(s =>
                        s.UserId == userId.Value &&
                        s.Keyword.ToLower() == query.ToLower());

                if (existingSearch != null)
                {
                    // Update timestamp if keyword already exists
                    existingSearch.SearchedAt = DateTime.UtcNow;
                }
                else
                {
                    // Insert new keyword
                    _context.SearchHistories.Add(new SearchHistory
                    {
                        UserId = userId.Value,
                        Keyword = query
                    });
                }

                await _context.SaveChangesAsync();
            }

            // 🔥 Convert TMDB results into ContentCardDto
            var tmdbResults = await _tmdbService.SearchContent(query);

            var results = tmdbResults.Select(t => new ContentCardDto
            {
                TmdbId = t.Id,
                Title = t.Title ?? t.Name,
                MediaType = t.MediaType,
                PosterUrl = t.PosterPath
            }).ToList();

            return Ok(results);
        }

        // 🕘 SEARCH HISTORY 
        [HttpGet("search/history/{userId}")]
        public async Task<IActionResult> GetSearchHistory(Guid userId)
        {
            var history = await _context.SearchHistories
                .Where(s => s.UserId == userId)
                .OrderByDescending(s => s.SearchedAt)
                .Select(s => new
                {
                    s.Keyword,
                    s.SearchedAt
                })
                .ToListAsync();

            return Ok(history);
        }


        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetDetails(int id, [FromQuery] string mediaType = "tv")
        {
            try
            {
                // Get basic details
                var details = await _tmdbService.GetContentDetails(id, mediaType);

                // Get cast/crew data
                var cast = await _tmdbService.GetCast(id, mediaType);
                details.Cast = cast;

                // Get streaming platforms
                var platforms = await _watchmodeService.GetStreamingSources(id, mediaType);
                details.StreamingPlatforms = platforms;

                return Ok(details);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // ✨ NEW ENDPOINT - Returns cached trending (auto-refreshes if needed)
        [HttpGet("trending")]
        public async Task<IActionResult> GetTrending()
        {
            try
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
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
        [HttpGet("recommendations/{userId}")]
        public async Task<IActionResult> GetRecommendations(Guid userId)
        {
            // 1️⃣ Get user preferences
            var userGenres = await _context.UserGenrePreferences
                .Where(g => g.UserId == userId)
                .Select(g => g.Genre)
                .ToListAsync();

            var userGenreIds = userGenres
                .Where(g => TmdbGenreMap.ContainsKey(g))
                .Select(g => TmdbGenreMap[g])
                .ToList();

            var userLanguages = await _context.UserLanguagePreferences
                .Where(l => l.UserId == userId)
                .Select(l => l.Language)
                .ToListAsync();

            var userLanguageCodes = userLanguages
                .Where(l => TmdbLanguageMap.ContainsKey(l))
                .Select(l => TmdbLanguageMap[l])
                .ToList();

            // 2️⃣ Load trending cache
            var trending = await _context.TrendingCaches.ToListAsync();

            // 3️⃣ Filter by genres (if user selected any)
            if (userGenreIds.Any())
            {
                trending = trending
                    .Where(t => t.GenreIds != null &&
                                t.GenreIds.Any(g => userGenreIds.Contains(g)))
                    .ToList();
            }

            if (userLanguageCodes.Any())
            {
                trending = trending
                    .Where(t => t.Language != null &&
                                userLanguageCodes.Contains(t.Language))
                    .ToList();
            }

            // 4️⃣ (Optional later) Filter by language
            // We will plug this when we store language per content

            // 5️⃣ Sort by popularity
            trending = trending
                .OrderBy(t => t.TrendingRank)
                .Take(20)
                .ToList();

            // 6️⃣ Convert to DTO
            var result = trending.Select(t => new ContentCardDto
            {
                TmdbId = t.TmdbId,
                Title = t.Title,
                PosterUrl = t.PosterUrl ?? "",
                MediaType = t.MediaType
            }).ToList();

            return Ok(result);
        }

    }
}
    
