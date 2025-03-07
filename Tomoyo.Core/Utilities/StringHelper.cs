using Tomoyo.Core.Models;

namespace Tomoyo.Core.Utilities;

public static class StringHelper
{
    /// <summary>
    /// Get string from <see cref="ProfileType"/> that's already formatted and usable in file names
    /// </summary>
    /// <param name="profileType">The type of profile</param>
    /// <returns>Usable string for file names</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="profileType"/> is not recognized</exception>
    public static string GetProfileTypeString(ProfileType profileType)
    {
        return profileType switch
        {
            ProfileType.Base => "base",
            ProfileType.Cosplayer => "cosplayer",
            ProfileType.Photographer => "photographer",
            _ => throw new ArgumentOutOfRangeException(nameof(profileType), profileType, null)
        };
    }
}