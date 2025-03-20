namespace Tomoyo.Core.Utilities;

public static class FileHelper
{
    /// <summary>
    /// Generate new file name for profile related data
    /// </summary>
    /// <param name="userId">Owner of the profile data</param>
    /// <param name="profileDataType">The <see cref="ProfileDataType"/></param>
    /// <param name="oldFileName">Old file name for file extension</param>
    /// <returns></returns>
    public static string GenerateNewProfileDataFileName(string userId, ProfileDataType profileDataType, string oldFileName = "dummy.*")
    {
        return $"{userId}-{profileDataType.ToString().ToLower()}{Path.GetExtension(oldFileName)}";
    }
    
    /// <summary>
    /// Generate new file name for photo related data
    /// </summary>
    /// <param name="userId">Uploader user ID of the photo data</param>
    /// <param name="photoId">Photo ID</param>
    /// <param name="photoDataType">The <see cref="PhotoDataType"/></param>
    /// <param name="oldFileName">Old file name for file extension</param>
    /// <returns></returns>
    public static string GenerateNewPhotoDataFileName(string userId, int photoId, PhotoDataType photoDataType, string oldFileName = "dummy.*")
    {
        return $"{userId}-{photoId}-{photoDataType.ToString().ToLower()}{Path.GetExtension(oldFileName)}";
    }
    
    public enum ProfileDataType
    {
        Avatar,
        Cover
    }
    
    public enum PhotoDataType
    {
        Original,
        Thumbnail
    }
}