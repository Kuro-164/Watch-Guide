namespace WatchGuideAPI.DTOs
{
    public class WatchmodeDtos
    {
        public string Name { get; set; }
        public string? Logo { get; set; }
        public string? Url { get; set; }
        public string Type { get; set; }
    }

    public class WatchmodeSource
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Logo { get; set; }
        public string WebUrl { get; set; }
    }

    public class WatchmodeSearchResponse
    {
        public List<WatchmodeSearchResult> TitleResults { get; set; }
    }

    public class WatchmodeSearchResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}