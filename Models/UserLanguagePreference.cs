
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WatchGuideAPI.Models
{
    [Table("user_language_preferences")]
    public class UserLanguagePreference
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")]
        public Guid UserId { get; set; }

        [Column("language")]
        [Required]
        [MaxLength(20)]
        public string Language { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}