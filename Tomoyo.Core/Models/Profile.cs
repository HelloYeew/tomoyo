using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tomoyo.Core.Models;

/// <summary>
/// Base profile for application users, every user will have this object by default
/// </summary>
public class Profile
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(36)]
    public string UserId { get; set; } = null!;
    
    public TomoyoUser User { get; set; } = null!;
    
    [MaxLength(30)]
    public string? DisplayName { get; set; }
    
    [MaxLength(500)]
    public string? Avatar { get; set; }
    
    [MaxLength(500)]
    public string? Cover { get; set; }
    
    [MaxLength(500)]
    public string? Bio { get; set; }
}