using Microsoft.AspNetCore.Identity;

namespace Tomoyo.Core.Models;

public class TomoyoUser : IdentityUser
{
    public Profile? Profile { get; set; }
    
    public ICollection<Photo> UploadPhotos { get; }
}