using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tomoyo.Core.Models;

/// <summary>
/// Cosplayer side profile bind with the user, created when user want to create
/// </summary>
public class PhotographerProfile
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string? UserId { get; set; }
    public TomoyoUser? User { get; set; }
    
    [MaxLength(30)]
    public string? DisplayName { get; set; }
    
    [MaxLength(500)]
    public string? Avatar { get; set; }
    
    [MaxLength(500)]
    public string? Cover { get; set; }
    
    [MaxLength(500)]
    public string? Bio { get; set; }
}