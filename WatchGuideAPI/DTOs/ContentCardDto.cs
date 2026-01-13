namespace WatchGuideAPI.DTOs
{
    public class ContentCardDto
    {
        public int TmdbId { get; set; }
        public string Title { get; set; } = "";
        public string PosterUrl { get; set; } = "";
        public string MediaType { get; set; } = "";
    }
}