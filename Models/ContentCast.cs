using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WatchGuideAPI.Models
{

    [Table("content_cast")]
    public class ContentCast
    {
        [Key]
        [Column("cast_id")]
        public int CastId { get; set; }

        [Column("content_id")]
        public int ContentId { get; set; }

        [Column("actor_name")]
        [Required]
        [MaxLength(100)]
        public string ActorName { get; set; }

        [Column("character_name")]
        [MaxLength(100)]
        public string CharacterName { get; set; }

        [Column("profile_url")]
        public string ProfileUrl { get; set; }

        [Column("cast_order")]
        public int? CastOrder { get; set; }

        [ForeignKey("ContentId")]
        public Content Content { get; set; }
    }
}