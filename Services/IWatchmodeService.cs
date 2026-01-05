using WatchGuideAPI.DTOs;

namespace WatchGuideAPI.Services
{
    public interface IWatchmodeService
    {
        Task<List<StreamingPlatformDto>> GetStreamingSources(int tmdbId, string mediaType);
    }
}
