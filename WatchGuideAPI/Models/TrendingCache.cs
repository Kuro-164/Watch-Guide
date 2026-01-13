// Models/TrendingCache.cs

namespace WatchGuideAPI.Models
{
    public class TrendingCache
    {
        public int Id { get; set; }
        public int TmdbId { get; set; }
        public string Title { get; set; }
        public string MediaType { get; set; } // "movie" or "tv"
        public string? PosterUrl { get; set; }
        public string? BackdropUrl { get; set; }
        public decimal? Rating { get; set; }
        public string? Overview { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int[]? GenreIds { get; set; }
        public int TrendingRank { get; set; }
        public DateTime CachedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
