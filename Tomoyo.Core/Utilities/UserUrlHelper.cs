using Tomoyo.Core.Models;

namespace Tomoyo.Core.Utilities;

public static class UserUrlHelper
{
    public static string GetAvatarUrl(this TomoyoUser user)
    {
        return "/api/profiles/avatar/" + user.Id;
    }

    public static string GetProfileUrl(this TomoyoUser user)
    {
        return "/profile/" + user.Id;
    }
}