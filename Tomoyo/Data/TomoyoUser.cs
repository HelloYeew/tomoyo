using Microsoft.AspNetCore.Identity;

namespace Tomoyo.Data;

public class TomoyoUser : IdentityUser
{
    public BaseProfile? BaseProfile { get; set; }
    public CosplayerProfile? CosplayerProfile { get; set; }
    public PhotographerProfile? PhotographerProfile { get; set; }
}