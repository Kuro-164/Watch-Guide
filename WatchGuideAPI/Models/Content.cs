using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WatchGuideAPI.Models
{
    [Table("content")]
    public class Content
    {
        [Key]
        [Column("content_id")]
        public int ContentId { get; set; }

        [Column("tmdb_id")]
        [Required]
        public int TmdbId { get; set; }

        [Column("title")]
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Column("type")]
        [Required]
        [MaxLength(10)]
        public string Type { get; set; } // 'movie' or 'tv'

        [Column("description")]
        public string Description { get; set; }

        [Column("language")]
        [MaxLength(20)]
        public string? Language { get; set; }

        [Column("rating")]
        public float? Rating { get; set; }

        [Column("vote_count")]
        public int? VoteCount { get; set; }

        [Column("poster_url")]
        public string? PosterUrl { get; set; }

        [Column("backdrop_url")]
        public string? BackdropUrl { get; set; }

        [Column("release_date")]
        public DateTime? ReleaseDate { get; set; }

        [Column("status")]
        [MaxLength(50)]
        public string Status { get; set; }

        [Column("last_updated")]
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        [Column("cached_until")]
        public DateTime CachedUntil { get; set; } = DateTime.UtcNow.AddDays(7);

        [Column("number_of_seasons")]
        public int? NumberOfSeasons { get; set; }

        [Column("number_of_episodes")]
        public int? NumberOfEpisodes { get; set; }

        [Column("next_episode_date")]
        public DateTime? NextEpisodeDate { get; set; }

        [Column("next_episode_name")]
        [MaxLength(255)]
        public string? NextEpisodeName { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<ContentGenre> ContentGenres { get; set; }
        public ICollection<ContentCast> ContentCast { get; set; }
        public ICollection<ContentPlatform> ContentPlatforms { get; set; }
    }
}