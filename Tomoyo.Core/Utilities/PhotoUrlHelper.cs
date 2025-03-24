using Tomoyo.Core.Models;

namespace Tomoyo.Core.Utilities;

public static class PhotoUrlHelper
{
    public static string GetPhotoUrl(this Photo photo)
    {
        return "/api/photos/" + photo.Id;
    }
}