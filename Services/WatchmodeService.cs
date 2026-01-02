using System.Text.Json;
using WatchGuideAPI.DTOs;

namespace WatchGuideAPI.Services
{
    public class WatchmodeService : IWatchmodeService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public WatchmodeService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<List<WatchmodeSourceDto>> GetStreamingSources(int tmdbId, string mediaType)
        {
            var apiKey = _configuration["APIs:Watchmode:ApiKey"];

            if (string.IsNullOrEmpty(apiKey))
                return new List<WatchmodeSourceDto>();

            var url =
                $"https://api.watchmode.com/v1/title/{tmdbId}/sources/?apiKey={apiKey}";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return new List<WatchmodeSourceDto>();

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<WatchmodeSourceDto>>(json)
                   ?? new List<WatchmodeSourceDto>();
        }
    }
}
