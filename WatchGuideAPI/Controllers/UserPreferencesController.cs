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

        // ================= SAVE / UPDATE =================
        [HttpPost("{userId}")]
        public async Task<IActionResult> SavePreferences(
            Guid userId,
            UserPreferencesRequest request)
        {
            var userExists = await _context.Users.AnyAsync(u => u.UserId == userId);
            if (!userExists)
                return NotFound(new { message = "User not found" });

            await RemoveExistingPreferences(userId);
            AddNewPreferences(userId, request);

            await _context.SaveChangesAsync();
            return Ok(new { message = "Preferences saved successfully" });
        }

        // ================= GET =================
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetPreferences(Guid userId)
        {
            var userExists = await _context.Users.AnyAsync(u => u.UserId == userId);
            if (!userExists)
                return NotFound(new { message = "User not found" });

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

        // ================= HELPERS =================
        private async Task RemoveExistingPreferences(Guid userId)
        {
            var languages = await _context.UserLanguagePreferences
                .Where(p => p.UserId == userId)
                .ToListAsync();

            var genres = await _context.UserGenrePreferences
                .Where(p => p.UserId == userId)
                .ToListAsync();

            _context.RemoveRange(languages);
            _context.RemoveRange(genres);
        }

        private void AddNewPreferences(Guid userId, UserPreferencesRequest request)
        {
            if (request.Languages != null)
            {
                foreach (var lang in request.Languages)
                {
                    _context.UserLanguagePreferences.Add(new UserLanguagePreference
                    {
                        UserId = userId,
                        Language = lang
                    });
                }
            }

            if (request.Genres != null)
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
        }
    }
}
