// DTOs/UserPreferencesDto.cs
namespace WatchGuideAPI.DTOs
{
    public class UserPreferencesRequest
    {
        public List<string> Languages { get; set; }
        public List<string> Genres { get; set; }
    }

    public class UserPreferencesResponse
    {
        public Guid UserId { get; set; }
        public List<string> Languages { get; set; }
        public List<string> Genres { get; set; }
    }
}