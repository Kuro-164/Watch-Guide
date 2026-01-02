namespace WatchGuideAPI.DTOs
{
    public class WatchmodeSourceDto
    {
        public string Name { get; set; }          // Netflix, Prime Video, etc.
        public string Type { get; set; }          // subscription / rent / buy
        public string Region { get; set; }        // IN, US, etc.
        public string WebUrl { get; set; }        // Redirect link
    }
}
