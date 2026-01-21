using System.Text.Json;
using WatchGuideAPI.DTOs;

namespace WatchGuideAPI.Services
{
    public interface ITMDBService
    {
        Task<List<TMDBSearchResult>> SearchContent(string query);
        Task<ContentDetailsResponse> GetContentDetails(int tmdbId, string mediaType);
        Task<List<TMDBSearchResult>> GetWeeklyTrending();
        Task<List<CastDto>> GetCast(int tmdbId, string mediaType);
    }

    public class TMDBService : ITMDBService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _baseUrl;

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

        public async Task<List<TMDBSearchResult>> SearchContent(string query)
        {
            var url = $"{_baseUrl}/search/multi?api_key={_apiKey}&query={Uri.EscapeDataString(query)}";
            var json = await GetJson(url);
            var result = JsonSerializer.Deserialize<SearchResponse>(json, JsonOptions);

            return result?.Results?
                .Where(r => r.MediaType == "movie" || r.MediaType == "tv")
                .ToList() ?? new();
        }

        public async Task<ContentDetailsResponse> GetContentDetails(int tmdbId, string mediaType)
        {
            var endpoint = mediaType == "movie" ? "movie" : "tv";
            var url = $"{_baseUrl}/{endpoint}/{tmdbId}?api_key={_apiKey}&language=en-US";
            var json = await GetJson(url);

            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            return new ContentDetailsResponse
            {
                TmdbId = tmdbId,
                Type = mediaType,
                Title = mediaType == "movie"
                    ? root.GetProperty("title").GetString()
                    : root.GetProperty("name").GetString(),
                Description = root.GetProperty("overview").GetString(),
                Language = root.GetProperty("original_language").GetString(),
                Rating = root.GetProperty("vote_average").GetSingle(),
                PosterUrl = BuildImageUrl(root, "poster_path", "w500"),
                BackdropUrl = BuildImageUrl(root, "backdrop_path", "original"),
                Genres = root.GetProperty("genres")
                    .EnumerateArray()
                    .Select(g => g.GetProperty("name").GetString())
                    .ToList()
            };
        }

        public async Task<List<TMDBSearchResult>> GetWeeklyTrending()
        {
            var url = $"{_baseUrl}/trending/all/week?api_key={_apiKey}&language=en-US";
            var json = await GetJson(url);
            var result = JsonSerializer.Deserialize<SearchResponse>(json, JsonOptions);

            return result?.Results?
                .Where(r => r.MediaType == "movie" || r.MediaType == "tv")
                .ToList() ?? new();
        }

        public async Task<List<CastDto>> GetCast(int tmdbId, string mediaType)
        {
            var url = $"{_baseUrl}/{mediaType}/{tmdbId}/credits?api_key={_apiKey}";
            var json = await GetJson(url);
            var credits = JsonSerializer.Deserialize<TmdbCreditsDto>(json, JsonOptions);

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

        private async Task<string> GetJson(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private static string? BuildImageUrl(JsonElement root, string property, string size) =>
            root.TryGetProperty(property, out var el) && el.ValueKind != JsonValueKind.Null
                ? $"https://image.tmdb.org/t/p/{size}{el.GetString()}"
                : null;
    }
}