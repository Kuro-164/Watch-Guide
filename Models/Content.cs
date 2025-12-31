using System;
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
        public int TmdbId { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("type")]
        public string Type { get; set; } // "movie" or "tv"

        [Column("description")]
        public string Description { get; set; }

        [Column("poster_url")]
        public string PosterUrl { get; set; }

        [Column("rating")]
        public float? Rating { get; set; }

        [Column("cached_until")]
        public DateTime CachedUntil { get; set; }
    }
}