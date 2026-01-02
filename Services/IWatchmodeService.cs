using WatchGuideAPI.DTOs;

namespace WatchGuideAPI.Services
{
    public interface IWatchmodeService
    {
        Task<List<WatchmodeSourceDto>> GetStreamingSources(int tmdbId, string mediaType);
    }
}
