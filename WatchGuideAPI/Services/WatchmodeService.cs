using System.Text.Json;
using WatchGuideAPI.DTOs;

namespace WatchGuideAPI.Services
{
    public class WatchmodeService : IWatchmodeService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _baseUrl;
        private readonly ILogger<WatchmodeService> _logger;

        public WatchmodeService(IConfiguration configuration, HttpClient httpClient, ILogger<WatchmodeService> logger)
        {
            _httpClient = httpClient;
            _apiKey = configuration["APIs:Watchmode:ApiKey"];
            _baseUrl = configuration["APIs:Watchmode:BaseUrl"];
            _logger = logger;
        }

        public async Task<List<StreamingPlatformDto>> GetStreamingSources(int tmdbId, string mediaType)
        {
            try
            {
                var watchmodeId = await GetWatchmodeId(tmdbId, mediaType);

                if (watchmodeId == null)
                {
                    _logger.LogWarning($"No Watchmode ID found for TMDB ID: {tmdbId}");
                    return new List<StreamingPlatformDto>();
                }

                var url = $"{_baseUrl}/title/{watchmodeId}/sources/?apiKey={_apiKey}&regions=IN";
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    return new List<StreamingPlatformDto>();

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
                };

                var sources = JsonSerializer.Deserialize<List<WatchmodeSource>>(content, options);

                return sources?
                    .Where(s => !string.IsNullOrEmpty(s.Name))
                    .GroupBy(s => s.Name)
                    .Select(g => new StreamingPlatformDto
                    {
                        Name = g.First().Name,
                        Logo = g.First().Logo,
                        Url = g.First().WebUrl,
                        Type = FormatType(g.First().Type)
                    })
                    .ToList() ?? new List<StreamingPlatformDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching streaming platforms");
                return new List<StreamingPlatformDto>();
            }
        }

        private async Task<int?> GetWatchmodeId(int tmdbId, string mediaType)
        {
            try
            {
                var searchField = mediaType == "movie" ? "tmdb_movie_id" : "tmdb_tv_id";
                var url = $"{_baseUrl}/search/?apiKey={_apiKey}&search_field={searchField}&search_value={tmdbId}";

                var response = await _httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                    return null;

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
                };

                var searchResult = JsonSerializer.Deserialize<WatchmodeSearchResponse>(content, options);
                return searchResult?.TitleResults?.FirstOrDefault()?.Id;
            }
            catch
            {
                return null;
            }
        }

        private string FormatType(string type) =>
            type?.ToLower() switch
            {
                "sub" => "Subscription",
                "free" => "Free",
                "rent" => "Rent",
                "buy" => "Buy",
                _ => type ?? "Other"
            };
    }
}