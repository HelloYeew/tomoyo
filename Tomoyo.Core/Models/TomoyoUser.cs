using Microsoft.AspNetCore.Identity;

namespace Tomoyo.Core.Models;

public class TomoyoUser : IdentityUser
{
    public BaseProfile? BaseProfile { get; set; }
    public CosplayerProfile? CosplayerProfile { get; set; }
    public PhotographerProfile? PhotographerProfile { get; set; }
}