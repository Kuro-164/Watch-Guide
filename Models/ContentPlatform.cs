// ContentPlatform.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WatchGuideAPI.Models
{

    [Table("content_platforms")]
    public class ContentPlatform
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("content_id")]
        public int ContentId { get; set; }

        [Column("platform_id")]
        public int PlatformId { get; set; }

        [Column("streaming_url")]
        [Required]
        public string StreamingUrl { get; set; }

        [Column("stream_type")]
        [MaxLength(20)]
        public string StreamType { get; set; }

        [Column("last_updated")]
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        [Column("cached_until")]
        public DateTime CachedUntil { get; set; } = DateTime.UtcNow.AddDays(7);

        [ForeignKey("ContentId")]
        public Content Content { get; set; }

        [ForeignKey("PlatformId")]
        public StreamingPlatform Platform { get; set; }
    }
}