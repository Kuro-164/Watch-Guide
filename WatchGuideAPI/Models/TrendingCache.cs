using System.ComponentModel.DataAnnotations.Schema;

namespace WatchGuideAPI.Models
{
    [Table("trending_cache")]
    public class TrendingCache
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("tmdb_id")]
        public int TmdbId { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("media_type")]
        public string MediaType { get; set; }

        [Column("poster_url")]
        public string? PosterUrl { get; set; }

        [Column("backdrop_url")]
        public string? BackdropUrl { get; set; }

        [Column("rating")]
        public decimal? Rating { get; set; }

        [Column("overview")]
        public string? Overview { get; set; }

        [Column("release_date")]
        public DateTime? ReleaseDate { get; set; }

        [Column("genre_ids")]
        public int[]? GenreIds { get; set; }

        [Column("language")]
        public string? Language { get; set; }

        [Column("trending_rank")]
        public int TrendingRank { get; set; }

        [Column("cached_at")]
        public DateTime CachedAt { get; set; }

        [Column("expires_at")]
        public DateTime ExpiresAt { get; set; }
    }
}
