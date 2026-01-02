using Microsoft.AspNetCore.Mvc;
using WatchGuideAPI.Services;

namespace WatchGuideAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContentController : ControllerBase
    {
        private readonly ITMDBService _tmdbService;
        private readonly IContentService _contentService;

        public ContentController(ITMDBService tmdbService, IContentService contentService)
        {
            _tmdbService = tmdbService;
            _contentService = contentService;
        }

        // Search content (no caching - always fresh)
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(query))
                {
                    return BadRequest(new { message = "Search query is required" });
                }

                var results = await _tmdbService.SearchContent(query);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Get content details WITH caching and streaming sources
        [HttpGet("{tmdbId}/details")]
        public async Task<IActionResult> GetDetails(int tmdbId, [FromQuery] string mediaType)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(mediaType))
                {
                    return BadRequest(new { message = "Media type (movie or tv) is required" });
                }

                // This will check cache first, then fetch fresh data if needed
                var details = await _contentService.GetOrCacheContent(tmdbId, mediaType);
                return Ok(details);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Get trending content for home page
        [HttpGet("trending")]
        public async Task<IActionResult> GetTrending([FromQuery] int count = 10)
        {
            try
            {
                var trending = await _contentService.GetTrendingContent(count);
                return Ok(trending);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Get personalized recommendations
        [HttpGet("recommendations/{userId}")]
        public async Task<IActionResult> GetRecommendations(Guid userId, [FromQuery] int count = 10)
        {
            try
            {
                var recommendations = await _contentService.GetRecommendations(userId, count);
                return Ok(recommendations);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}