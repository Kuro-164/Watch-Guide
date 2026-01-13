// SearchHistory.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchGuideAPI.Models;

[Table("search_history")]
public class SearchHistory
{
    [Key]
    [Column("search_id")]
    public int SearchId { get; set; }

    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("keyword")]
    [Required]
    [MaxLength(255)]
    public string Keyword { get; set; }

    [Column("searched_at")]
    public DateTime SearchedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey("UserId")]
    public User User { get; set; }
}
