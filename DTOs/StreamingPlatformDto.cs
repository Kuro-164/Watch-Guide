// DTOs/StreamingPlatformDto.cs

namespace WatchGuideAPI.DTOs
{
    public class StreamingPlatformDto
    {
        public string Name { get; set; }        // "Netflix", "Prime Video", etc.
        public string? Logo { get; set; }       // Platform logo URL
        public string? Url { get; set; }        // Direct link to watch
        public string Type { get; set; }        // "Subscription", "Free", "Rent", "Buy"
    }
}