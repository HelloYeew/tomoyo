using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tomoyo.Core.Models;

public class Photo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [MaxLength(200)]
    public string? Name { get; set; }
    
    [MaxLength(200)]
    public string? FileName { get; set; }
    
    [MaxLength(36)]
    public string? UploadUserId { get; set; }
    
    public TomoyoUser? User { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
}