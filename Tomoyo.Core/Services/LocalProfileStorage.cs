using Tomoyo.Core.Configurations;
using Tomoyo.Core.Models;
using Tomoyo.Core.Utilities;

namespace Tomoyo.Core.Services;

public class LocalProfileStorage : IProfileStorage
{
    public string BaseDirectory { get; }
    
    private const string AvatarDirectory = "avatars";
    private const string CoverDirectory = "covers";
    
    public LocalProfileStorage(string? baseDirectory = null)
    {
        BaseDirectory = baseDirectory ?? CoreSettings.ProfileStorageBaseDirectory;
        if (!Directory.Exists(GetBaseDirectoryFullPath()))
            Directory.CreateDirectory(GetBaseDirectoryFullPath());
        if (!Directory.Exists(GetAvatarDirectoryFullPath()))
            Directory.CreateDirectory(GetAvatarDirectoryFullPath());
        if (!Directory.Exists(GetCoverDirectoryFullPath()))
            Directory.CreateDirectory(GetCoverDirectoryFullPath());
    }
    
    public async Task<string> UploadAvatarAsync(string userId, ProfileType profileType, Stream stream, string fileName, CancellationToken cancellationToken = default)
    {
        string newFileName = FileHelper.GenerateNewProfileDataFileName(userId, FileHelper.ProfileDataType.Avatar, profileType, fileName);
        string filePath = Path.Combine(GetAvatarDirectoryFullPath(), newFileName);
        await using FileStream fileStream = new FileStream(filePath, FileMode.Create);
        await stream.CopyToAsync(fileStream, cancellationToken);
        return newFileName;
    }
    
    private string GetBaseDirectoryFullPath() => Path.Combine(BaseDirectory);
    private string GetAvatarDirectoryFullPath() => Path.Combine(GetBaseDirectoryFullPath(), AvatarDirectory);
    private string GetCoverDirectoryFullPath() => Path.Combine(GetBaseDirectoryFullPath(), CoverDirectory);
}