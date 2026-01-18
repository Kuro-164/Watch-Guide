using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WatchGuideAPI.Models
{
    // Stores cast details for a movie or TV show
    [Table("content_cast")]
    public class ContentCast
    {
        [Key]
        [Column("cast_id")]
        public int CastId { get; set; }

        // Foreign key linking to Content table
        [Column("content_id")]
        public int ContentId { get; set; }

        [Required, MaxLength(100)]
        [Column("actor_name")]
        public string ActorName { get; set; }

        [MaxLength(100)]
        [Column("character_name")]
        public string CharacterName { get; set; }

        // Actor profile image URL
        [Column("profile_url")]
        public string ProfileUrl { get; set; }

        // Used to sort cast by importance
        [Column("cast_order")]
        public int? CastOrder { get; set; }

        // Navigation property to parent Content
        [ForeignKey("ContentId")]
        public Content Content { get; set; }
    }
}
