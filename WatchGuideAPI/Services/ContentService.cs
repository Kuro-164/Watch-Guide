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

        public async Task<ContentDetailsResponse> GetOrCacheContent(int tmdbId, string mediaType)
        {
            var content = await GetValidCachedContent(tmdbId, mediaType);
            if (content != null)
                return MapToResponse(content);

            var tmdbDetails = await _tmdbService.GetContentDetails(tmdbId, mediaType);
            var tmdbCast = await _tmdbService.GetCast(tmdbId, mediaType);

            content = await GetOrCreateContent(tmdbId, mediaType, tmdbDetails);
            UpdateContent(content, tmdbDetails);
            UpdateCast(content.ContentId, tmdbCast);
            UpdateGenres(content.ContentId, tmdbDetails.Genres);

            await _context.SaveChangesAsync();
            return MapToResponse(content);
        }

        // ================= TRENDING =================
        public async Task<List<Content>> GetTrendingContent(int count = 10)
        {
            return await _context.Content
                .Where(c => c.Rating >= 7.0)
                .OrderByDescending(c => c.Rating)
                .ThenByDescending(c => c.CreatedAt)
                .Take(count)
                .ToListAsync();
        }

        // ================= RECOMMENDATIONS =================
        public async Task<List<Content>> GetRecommendations(Guid userId, int count = 10)
        {
            var genres = await GetUserGenres(userId);
            var languages = await GetUserLanguages(userId);

            if (!genres.Any() && !languages.Any())
                return await GetDefaultRecommendations(count);

            var query = _context.Content
                .Include(c => c.ContentGenres)
                .Where(c => c.Rating >= 6.5);

            if (languages.Any())
                query = query.Where(c => c.Language != null && languages.Contains(c.Language.ToLower()));

            if (genres.Any())
                query = query.Where(c => c.ContentGenres.Any(g => genres.Contains(g.Genre.ToLower())));

            return await query
                .OrderByDescending(c => c.Rating)
                .ThenByDescending(c => c.VoteCount)
                .Take(count)
                .ToListAsync();
        }

        // ================= HELPERS =================

        private async Task<Content?> GetValidCachedContent(int tmdbId, string mediaType)
        {
            return await _context.Content
                .Include(c => c.ContentGenres)
                .FirstOrDefaultAsync(c =>
                    c.TmdbId == tmdbId &&
                    c.Type == mediaType &&
                    c.CachedUntil > DateTime.UtcNow
                );
        }

        private async Task<Content> GetOrCreateContent(
            int tmdbId,
            string mediaType,
            ContentDetailsResponse details)
        {
            var content = await _context.Content
                .Include(c => c.ContentGenres)
                .FirstOrDefaultAsync(c =>
                    c.TmdbId == tmdbId &&
                    c.Type == mediaType
                );

            if (content != null)
                return content;

            content = new Content
            {
                TmdbId = tmdbId,
                Type = mediaType,
                CreatedAt = DateTime.UtcNow
            };

            _context.Content.Add(content);
            await _context.SaveChangesAsync();

            return content;
        }

        private void UpdateContent(Content content, ContentDetailsResponse details)
        {
            content.Title = details.Title;
            content.Description = details.Description;
            content.Rating = details.Rating;
            content.PosterUrl = details.PosterUrl;
            content.BackdropUrl = details.BackdropUrl;
            content.LastUpdated = DateTime.UtcNow;
            content.CachedUntil = DateTime.UtcNow.AddDays(7);
        }

        private void UpdateCast(int contentId, List<CastDto> cast)
        {
            _context.ContentCast.RemoveRange(
                _context.ContentCast.Where(c => c.ContentId == contentId)
            );

            foreach (var c in cast)
            {
                _context.ContentCast.Add(new ContentCast
                {
                    ContentId = contentId,
                    ActorName = c.Name,
                    CharacterName = c.Character,
                    ProfileUrl = c.Photo
                });
            }
        }

        private void UpdateGenres(int contentId, List<string> genres)
        {
            _context.ContentGenres.RemoveRange(
                _context.ContentGenres.Where(g => g.ContentId == contentId)
            );

            foreach (var g in genres)
            {
                _context.ContentGenres.Add(new ContentGenre
                {
                    ContentId = contentId,
                    Genre = g
                });
            }
        }

        private async Task<List<string>> GetUserGenres(Guid userId)
        {
            return await _context.UserGenrePreferences
                .Where(p => p.UserId == userId)
                .Select(p => p.Genre.ToLower())
                .ToListAsync();
        }

        private async Task<List<string>> GetUserLanguages(Guid userId)
        {
            return await _context.UserLanguagePreferences
                .Where(p => p.UserId == userId)
                .Select(p => p.Language.ToLower())
                .ToListAsync();
        }

        private async Task<List<Content>> GetDefaultRecommendations(int count)
        {
            return await _context.Content
                .Where(c => c.Rating >= 7.5)
                .OrderByDescending(c => c.Rating)
                .ThenByDescending(c => c.VoteCount)
                .Take(count)
                .ToListAsync();
        }

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
                Genres = content.ContentGenres.Select(g => g.Genre).ToList()
            };
        }
    }
}
