using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchGuideAPI.Data;
using WatchGuideAPI.Models;
using WatchGuideAPI.Services;

namespace WatchGuideAPI.Controllers
{
    // Controllers/ContentController.cs

    [ApiController]
    [Route("api/[controller]")]
    public class ContentController : ControllerBase
    {
        private readonly ITMDBService _tmdbService;
        private readonly ITrendingService _trendingService; // NEW
        private readonly IContentService _contentService;
        private readonly AppDbContext _context;

        public ContentController(ITMDBService tmdbService, ITrendingService trendingService, IContentService contentService, AppDbContext context)
        {
            _tmdbService = tmdbService;
            _trendingService = trendingService;
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

            // 🔍 Existing TMDB search logic (unchanged)
            var results = await _tmdbService.SearchContent(query);
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
            var details = await _tmdbService.GetContentDetails(id, mediaType);
            return Ok(details);
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
            var data = await _contentService.GetRecommendations(userId);
            return Ok(data);
        }
    }
}
    
