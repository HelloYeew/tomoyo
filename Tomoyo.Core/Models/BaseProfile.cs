using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tomoyo.Core.Models;

/// <summary>
/// Base profile for application users, every user will have this object by default
/// </summary>
public class BaseProfile
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string UserId { get; set; }
    public TomoyoUser User { get; set; } = null!;
    
    [MaxLength(500)]
    public string? Bio { get; set; }
}