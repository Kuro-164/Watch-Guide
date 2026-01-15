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
            var tmdbCast = await _tmdbService.GetCast(tmdbId, mediaType);
            var streamingPlatforms = await _watchmodeService.GetStreamingSources(tmdbId, mediaType);

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

                // 🔥 UPDATE CAST (clear + insert)
                _context.ContentCast.RemoveRange(
                    _context.ContentCast.Where(c => c.ContentId == content.ContentId)
                );

                foreach (var cast in tmdbCast)
                {
                    _context.ContentCast.Add(new ContentCast
                    {
                        ContentId = content.ContentId,
                        ActorName = cast.Name,
                        CharacterName = cast.Character,
                        ProfileUrl = cast.Photo,
                        CastOrder = null
                    });
                }
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
        // Replace the GetRecommendations method in ContentService.cs

        public async Task<List<Content>> GetRecommendations(Guid userId, int count = 10)
        {
            // 1️⃣ Get user's preferred genres
            var userGenres = await _context.UserGenrePreferences
                .Where(p => p.UserId == userId)
                .Select(p => p.Genre.ToLower())
                .ToListAsync();

            // 2️⃣ Get user's preferred languages
            var userLanguages = await _context.UserLanguagePreferences
                .Where(p => p.UserId == userId)
                .Select(p => p.Language.ToLower())
                .ToListAsync();

            // 3️⃣ If no preferences set, return generic high-rated content
            if (!userGenres.Any() && !userLanguages.Any())
            {
                return await _context.Content
                    .Where(c => c.Rating >= 7.5)
                    .OrderByDescending(c => c.Rating)
                    .ThenByDescending(c => c.VoteCount)
                    .Take(count)
                    .ToListAsync();
            }

            // 4️⃣ Filter by user preferences
            var query = _context.Content
                .Include(c => c.ContentGenres)
                .Where(c => c.Rating >= 6.5); // Slightly lower threshold for personalized

            // Filter by language if user has language preferences
            if (userLanguages.Any())
            {
                query = query.Where(c =>
                    c.Language != null &&
                    userLanguages.Contains(c.Language.ToLower())
                );
            }

            // Filter by genre if user has genre preferences
            if (userGenres.Any())
            {
                query = query.Where(c =>
                    c.ContentGenres.Any(g =>
                        userGenres.Contains(g.Genre.ToLower())
                    )
                );
            }

            // 5️⃣ Return personalized recommendations
            return await query
                .OrderByDescending(c => c.Rating)
                .ThenByDescending(c => c.VoteCount)
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

                // Add Cast data
                Cast = _context.ContentCast
                    .Where(c => c.ContentId == content.ContentId)
                    .OrderBy(c => c.CastOrder ?? int.MaxValue)
                    .Select(c => new CastDto
                    {
                        Name = c.ActorName,
                        Character = c.CharacterName,
                        Photo = c.ProfileUrl
                    })
                    .ToList(),

                StreamingPlatforms = _context.ContentPlatforms
                    .Where(p => p.ContentId == content.ContentId)
                    .Select(p => new StreamingPlatformDto
                    {
                        Name = p.Platform.Name,
                        Logo = p.Platform.LogoUrl,
                        Url = p.Platform.BaseUrl,
                        Type = "Subscription"
                    })
                    .ToList()
            };
        }

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

    }
}
