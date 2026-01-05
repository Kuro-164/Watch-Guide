using WatchGuideAPI.DTOs;

namespace WatchGuideAPI.Services
{
    public interface IWatchmodeService
    {
        Task<List<WatchmodeDtos>> GetStreamingSources(int tmdbId, string mediaType);
    }
}
