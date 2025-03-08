using Tomoyo.Core.Models;

namespace Tomoyo.Core.Utilities;

public static class FileHelper
{
    /// <summary>
    /// Generate new file name for profile related data
    /// </summary>
    /// <param name="userId">Owner of the profile data</param>
    /// <param name="profileDataType">The <see cref="ProfileDataType"/></param>
    /// <param name="profileType">The <see cref="ProfileType"/></param>
    /// <param name="oldFileName">Old file name</param>
    /// <returns></returns>
    public static string GenerateNewProfileDataFileName(string userId, ProfileDataType profileDataType, ProfileType profileType, string oldFileName = "dummy.*")
    {
        return $"{userId}-{profileDataType.ToString().ToLower()}-{StringHelper.GetProfileTypeString(profileType)}{Path.GetExtension(oldFileName)}";
    }
    
    public enum ProfileDataType
    {
        Avatar,
        Cover
    }
}