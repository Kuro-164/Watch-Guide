// StreamingPlatform.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("streaming_platforms")]
public class StreamingPlatform
{
    [Key]
    [Column("platform_id")]
    public int PlatformId { get; set; }

    [Column("name")]
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Column("logo_url")]
    public string LogoUrl { get; set; }

    [Column("base_url")]
    public string BaseUrl { get; set; }
}