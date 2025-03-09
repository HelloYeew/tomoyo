using Microsoft.AspNetCore.Identity;

namespace Tomoyo.Core.Models;

public class TomoyoUser : IdentityUser
{
    public Profile? BaseProfile { get; set; }
}