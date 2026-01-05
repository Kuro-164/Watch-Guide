using Microsoft.AspNetCore.Mvc;
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

        public ContentController(ITMDBService tmdbService, ITrendingService trendingService, IContentService contentService)
        {
            _tmdbService = tmdbService;
            _trendingService = trendingService;
            _contentService = contentService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            var results = await _tmdbService.SearchContent(query);
            return Ok(results);
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
    
