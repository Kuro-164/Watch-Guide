using System.Text.Json;
using WatchGuideAPI.DTOs;

namespace WatchGuideAPI.Services
{
    // Contract for all TMDB-related operations
    public interface ITMDBService
    {
        Task<List<TMDBSearchResult>> SearchContent(string query);
        Task<ContentDetailsResponse> GetContentDetails(int tmdbId, string mediaType);
        Task<List<TMDBSearchResult>> GetWeeklyTrending();
        Task<List<CastDto>> GetCast(int tmdbId, string mediaType);
    }

    // Handles communication with TMDB API
    public class TMDBService : ITMDBService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        // Common JSON settings for TMDB responses
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        };

        public TMDBService(IConfiguration config, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiKey = config["APIs:TMDB:ApiKey"];
            _baseUrl = config["APIs:TMDB:BaseUrl"];
        }

        // Search movies and TV shows from TMDB
        public async Task<List<TMDBSearchResult>> SearchContent(string query)
        {
            // Build TMDB search URL
            var url = $"{_baseUrl}/search/multi?api_key={_apiKey}&query={Uri.EscapeDataString(query)}";

            // Call TMDB and get raw JSON
            var json = await GetJson(url);

            // Convert JSON into SearchResponse DTO
            var result = JsonSerializer.Deserialize<SearchResponse>(json, JsonOptions);

            // Return only movies and TV shows
            return result?.Results?
                .Where(r => r.MediaType == "movie" || r.MediaType == "tv")
                .ToList()
                ?? new();
        }

        // Get detailed information for a movie or TV show
        public async Task<ContentDetailsResponse> GetContentDetails(int tmdbId, string mediaType)
        {
            // Choose correct TMDB endpoint based on type
            var endpoint = mediaType == "movie" ? "movie" : "tv";
            var url = $"{_baseUrl}/{endpoint}/{tmdbId}?api_key={_apiKey}&language=en-US";

            var json = await GetJson(url);

            // Parse JSON manually to extract required fields
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            return new ContentDetailsResponse
            {
                TmdbId = tmdbId,
                Type = mediaType,

                // Movie uses "title", TV uses "name"
                Title = mediaType == "movie"
                    ? root.GetProperty("title").GetString()
                    : root.GetProperty("name").GetString(),

                Description = root.GetProperty("overview").GetString(),
                Language = root.GetProperty("original_language").GetString(),
                Rating = root.GetProperty("vote_average").GetSingle(),

                // Build full image URLs from TMDB paths
                PosterUrl = BuildImageUrl(root, "poster_path", "w500"),
                BackdropUrl = BuildImageUrl(root, "backdrop_path", "original"),

                // Extract genre names
                Genres = root.GetProperty("genres")
                    .EnumerateArray()
                    .Select(g => g.GetProperty("name").GetString())
                    .ToList()
            };
        }

        // Get weekly trending movies and TV shows
        public async Task<List<TMDBSearchResult>> GetWeeklyTrending()
        {
            var url = $"{_baseUrl}/trending/all/week?api_key={_apiKey}&language=en-US";
            var json = await GetJson(url);

            var result = JsonSerializer.Deserialize<SearchResponse>(json, JsonOptions);

            // Filter only movie and tv results
            return result?.Results?
                .Where(r => r.MediaType == "movie" || r.MediaType == "tv")
                .ToList()
                ?? new();
        }

        // Get cast details for a movie or TV show
        public async Task<List<CastDto>> GetCast(int tmdbId, string mediaType)
        {
            var url = $"{_baseUrl}/{mediaType}/{tmdbId}/credits?api_key={_apiKey}";
            var json = await GetJson(url);

            var credits = JsonSerializer.Deserialize<TmdbCreditsDto>(json, JsonOptions);

            // Return top cast members who have profile images
            return credits.Cast
                .Where(c => c.ProfilePath != null)
                .Take(12)
                .Select(c => new CastDto
                {
                    Name = c.Name,
                    Character = c.Character,
                    Photo = $"https://image.tmdb.org/t/p/w200{c.ProfilePath}"
                })
                .ToList();
        }

        // ---------------- HELPER METHODS ----------------

        // Makes HTTP GET request and returns response JSON
        private async Task<string> GetJson(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        // Builds full TMDB image URL if image path exists
        private static string? BuildImageUrl(JsonElement root, string property, string size)
        {
            return root.TryGetProperty(property, out var el) && el.ValueKind != JsonValueKind.Null
                ? $"https://image.tmdb.org/t/p/{size}{el.GetString()}"
                : null;
        }
    }
}
