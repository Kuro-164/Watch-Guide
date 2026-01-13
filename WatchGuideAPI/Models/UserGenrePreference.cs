using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchGuideAPI.Models;

[Table("user_genre_preferences")]
public class UserGenrePreference
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("genre")]
    [Required]
    [MaxLength(50)]
    public string Genre { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
}