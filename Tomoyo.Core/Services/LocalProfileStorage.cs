using Tomoyo.Core.Configurations;
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
    
    public async Task<string> UploadAvatarAsync(string userId, Stream stream, string fileName, CancellationToken cancellationToken = default)
    {
        string newFileName = FileHelper.GenerateNewProfileDataFileName(userId, FileHelper.ProfileDataType.Avatar, fileName);
        string filePath = Path.Combine(GetAvatarDirectoryFullPath(), newFileName);
        await using FileStream fileStream = new FileStream(filePath, FileMode.Create);
        await stream.CopyToAsync(fileStream, cancellationToken);
        return newFileName;
    }

    public async Task<GetAvatarResult> GetAvatarAsync(string userId, CancellationToken cancellationToken = default)
    {
        string[] files = Directory.GetFiles(GetAvatarDirectoryFullPath(),
            FileHelper.GenerateNewProfileDataFileName(userId, FileHelper.ProfileDataType.Avatar));
        return files.Length == 0
            ? new GetAvatarResult
            {
                Avatar = new byte[0],
                FileName = ""
            }
            : new GetAvatarResult
            {
                Avatar = await File.ReadAllBytesAsync(files[0], cancellationToken),
                FileName = Path.GetFileName(files[0])
            };
    }

    private string GetBaseDirectoryFullPath() => Path.Combine(BaseDirectory);
    private string GetAvatarDirectoryFullPath() => Path.Combine(GetBaseDirectoryFullPath(), AvatarDirectory);
    private string GetCoverDirectoryFullPath() => Path.Combine(GetBaseDirectoryFullPath(), CoverDirectory);
}