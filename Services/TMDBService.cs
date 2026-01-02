using System.Text.Json;
using WatchGuideAPI.DTOs;

namespace WatchGuideAPI.Services
{
    public interface ITMDBService
    {
        Task<List<TMDBSearchResult>> SearchContent(string query);
        Task<ContentDetailsResponse> GetContentDetails(int tmdbId, string mediaType);
    }

    public class TMDBService : ITMDBService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public TMDBService(IConfiguration configuration, HttpClient httpClient)
        {
            _httpClient = httpClient; // Use injected HttpClient
            _apiKey = configuration["APIs:TMDB:ApiKey"];
            _baseUrl = configuration["APIs:TMDB:BaseUrl"];
        }

        public async Task<List<TMDBSearchResult>> SearchContent(string query)
        {
            try
            {
                // FIX 1: Use search/multi with language parameter for better results
                string url = $"{_baseUrl}/search/multi?api_key={_apiKey}&query={Uri.EscapeDataString(query)}&language=en-US";

                Console.WriteLine($"Calling TMDB: {url}"); // DEBUG: Log the URL

                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"TMDB Response: {content}"); // DEBUG: Log response

                // FIX 2: Use more flexible JSON options to handle missing properties
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
                };

                var result = JsonSerializer.Deserialize<SearchResponse>(content, options);

                // Filter only movies and TV shows
                var filteredResults = result?.Results?
                    .Where(r => r.MediaType == "movie" || r.MediaType == "tv")
                    .ToList() ?? new List<TMDBSearchResult>();

                Console.WriteLine($"Filtered results count: {filteredResults.Count}"); // DEBUG

                return filteredResults;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"TMDB Error: {ex.Message}"); // DEBUG
                throw new Exception($"TMDB search failed: {ex.Message}");
            }
        }

        public async Task<ContentDetailsResponse> GetContentDetails(int tmdbId, string mediaType)
        {
            try
            {
                string endpoint = mediaType == "movie" ? "movie" : "tv";
                string url = $"{_baseUrl}/{endpoint}/{tmdbId}?api_key={_apiKey}&language=en-US";

                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var jsonDoc = JsonDocument.Parse(content);
                var root = jsonDoc.RootElement;

                var details = new ContentDetailsResponse
                {
                    TmdbId = tmdbId,
                    Title = mediaType == "movie"
                        ? root.GetProperty("title").GetString()
                        : root.GetProperty("name").GetString(),
                    Type = mediaType,
                    Description = root.GetProperty("overview").GetString(),
                    PosterUrl = root.TryGetProperty("poster_path", out var poster) && !poster.ValueKind.Equals(JsonValueKind.Null)
                        ? $"https://image.tmdb.org/t/p/w500{poster.GetString()}"
                        : null,
                    BackdropUrl = root.TryGetProperty("backdrop_path", out var backdrop) && !backdrop.ValueKind.Equals(JsonValueKind.Null)
                        ? $"https://image.tmdb.org/t/p/original{backdrop.GetString()}"
                        : null,
                    Rating = root.TryGetProperty("vote_average", out var rating)
                        ? (float)rating.GetDouble()
                        : 0f,
                    Genres = root.TryGetProperty("genres", out var genres)
                        ? genres.EnumerateArray()
                            .Select(g => g.GetProperty("name").GetString())
                            .ToList()
                        : new List<string>(),
                    StreamingPlatforms = new List<string>()
                };

                return details;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get content details: {ex.Message}");
            }
        }
    }
}