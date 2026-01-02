using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WatchGuideAPI.Models
{

    [Table("content_genres")]
    public class ContentGenre
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("content_id")]
        public int ContentId { get; set; }

        [Column("genre")]
        [Required]
        [MaxLength(50)]
        public string Genre { get; set; }

        [ForeignKey("ContentId")]
        public Content Content { get; set; }
    }
}