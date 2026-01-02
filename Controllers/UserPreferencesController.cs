using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchGuideAPI.Data;
using WatchGuideAPI.DTOs;
using WatchGuideAPI.Models;

namespace WatchGuideAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserPreferencesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserPreferencesController(AppDbContext context)
        {
            _context = context;
        }

        // Save or update user preferences
        [HttpPost("{userId}")]
        public async Task<IActionResult> SavePreferences(Guid userId, [FromBody] UserPreferencesRequest request)
        {
            try
            {
                // Check if user exists
                var user = await _context.Users.FindAsync(userId);
                if (user == null)
                {
                    return NotFound(new { message = "User not found" });
                }

                // Remove existing preferences
                var existingLangPrefs = await _context.UserLanguagePreferences
                    .Where(p => p.UserId == userId)
                    .ToListAsync();
                _context.UserLanguagePreferences.RemoveRange(existingLangPrefs);

                var existingGenrePrefs = await _context.UserGenrePreferences
                    .Where(p => p.UserId == userId)
                    .ToListAsync();
                _context.UserGenrePreferences.RemoveRange(existingGenrePrefs);

                // Add new language preferences
                if (request.Languages != null && request.Languages.Any())
                {
                    foreach (var language in request.Languages)
                    {
                        _context.UserLanguagePreferences.Add(new UserLanguagePreference
                        {
                            UserId = userId,
                            Language = language
                        });
                    }
                }

                // Add new genre preferences
                if (request.Genres != null && request.Genres.Any())
                {
                    foreach (var genre in request.Genres)
                    {
                        _context.UserGenrePreferences.Add(new UserGenrePreference
                        {
                            UserId = userId,
                            Genre = genre
                        });
                    }
                }

                await _context.SaveChangesAsync();

                return Ok(new { message = "Preferences saved successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Failed to save preferences: {ex.Message}" });
            }
        }

        // Get user preferences
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetPreferences(Guid userId)
        {
            try
            {
                var user = await _context.Users.FindAsync(userId);
                if (user == null)
                {
                    return NotFound(new { message = "User not found" });
                }

                var languages = await _context.UserLanguagePreferences
                    .Where(p => p.UserId == userId)
                    .Select(p => p.Language)
                    .ToListAsync();

                var genres = await _context.UserGenrePreferences
                    .Where(p => p.UserId == userId)
                    .Select(p => p.Genre)
                    .ToListAsync();

                return Ok(new UserPreferencesResponse
                {
                    UserId = userId,
                    Languages = languages,
                    Genres = genres
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Failed to get preferences: {ex.Message}" });
            }
        }
    }
}