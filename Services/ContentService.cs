using Microsoft.EntityFrameworkCore;
using WatchGuideAPI.Data;
using WatchGuideAPI.DTOs;
using WatchGuideAPI.Models;

namespace WatchGuideAPI.Services
{
    public interface IContentService
    {
        Task<ContentDetailsResponse> GetOrCacheContent(int tmdbId, string mediaType);
        Task<List<Content>> GetTrendingContent(int count = 10);
        Task<List<Content>> GetRecommendations(Guid userId, int count = 10);
    }

    public class ContentService : IContentService
    {
        private readonly AppDbContext _context;
        private readonly ITMDBService _tmdbService;
        private readonly IWatchmodeService _watchmodeService;

        public ContentService(
            AppDbContext context,
            ITMDBService tmdbService,
            IWatchmodeService watchmodeService)
        {
            _context = context;
            _tmdbService = tmdbService;
            _watchmodeService = watchmodeService;
        }

        // 🔥 AUTO-CACHE FROM TMDB
        public async Task<ContentDetailsResponse> GetOrCacheContent(int tmdbId, string mediaType)
        {
            // 1️⃣ Try valid cache
            var content = await _context.Content
                .Include(c => c.ContentGenres)
                .FirstOrDefaultAsync(c =>
                    c.TmdbId == tmdbId &&
                    c.Type == mediaType &&
                    c.CachedUntil > DateTime.UtcNow
                );

            if (content != null)
            {
                return MapToResponse(content);
            }

            // 2️⃣ Fetch from TMDB
            var tmdbDetails = await _tmdbService.GetContentDetails(tmdbId, mediaType);

            // 3️⃣ Check if content exists (expired cache)
            content = await _context.Content
                .Include(c => c.ContentGenres)
                .FirstOrDefaultAsync(c =>
                    c.TmdbId == tmdbId &&
                    c.Type == mediaType
                );

            if (content == null)
            {
                // Create new content
                content = new Content
                {
                    TmdbId = tmdbId,
                    Title = tmdbDetails.Title,
                    Type = mediaType,
                    Description = tmdbDetails.Description,
                    Language = "en",
                    Rating = tmdbDetails.Rating,
                    PosterUrl = tmdbDetails.PosterUrl,
                    BackdropUrl = tmdbDetails.BackdropUrl,
                    Status = "Released",
                    CreatedAt = DateTime.UtcNow
                };

                _context.Content.Add(content);
                await _context.SaveChangesAsync();
            }
            else
            {
                // Update existing content
                content.Title = tmdbDetails.Title;
                content.Description = tmdbDetails.Description;
                content.Rating = tmdbDetails.Rating;
                content.PosterUrl = tmdbDetails.PosterUrl;
                content.BackdropUrl = tmdbDetails.BackdropUrl;
            }

            // 4️⃣ Update cache timing
            content.LastUpdated = DateTime.UtcNow;
            content.CachedUntil = DateTime.UtcNow.AddDays(7);

            // 5️⃣ Update genres (clear + insert)
            _context.ContentGenres.RemoveRange(
                _context.ContentGenres.Where(g => g.ContentId == content.ContentId)
            );

            foreach (var genre in tmdbDetails.Genres)
            {
                _context.ContentGenres.Add(new ContentGenre
                {
                    ContentId = content.ContentId,
                    Genre = genre
                });
            }

            await _context.SaveChangesAsync();

            return MapToResponse(content);
        }

        // 🔥 TRENDING
        public async Task<List<Content>> GetTrendingContent(int count = 10)
        {
            return await _context.Content
                .Where(c => c.Rating >= 7.0)
                .OrderByDescending(c => c.Rating)
                .ThenByDescending(c => c.CreatedAt)
                .Take(count)
                .ToListAsync();
        }

        // 🔥 RECOMMENDATIONS (simple version)
        public async Task<List<Content>> GetRecommendations(Guid userId, int count = 10)
        {
            return await _context.Content
                .Where(c => c.Rating >= 7.5)
                .OrderByDescending(c => c.Rating)
                .Take(count)
                .ToListAsync();
        }

        // 🔥 RESPONSE MAPPER
        private ContentDetailsResponse MapToResponse(Content content)
        {
            return new ContentDetailsResponse
            {
                TmdbId = content.TmdbId,
                Title = content.Title,
                Type = content.Type,
                Description = content.Description,
                PosterUrl = content.PosterUrl,
                BackdropUrl = content.BackdropUrl,
                Rating = content.Rating ?? 0,

                Genres = content.ContentGenres?
                    .Select(g => g.Genre)
                    .ToList() ?? new List<string>(),

                StreamingPlatforms = _context.ContentPlatforms
                    .Where(p => p.ContentId == content.ContentId)
                    .Select(p => p.Platform.Name)
                    .ToList()
            };
        }
    }
}
