using Tomoyo.Core.Configurations;
using Tomoyo.Core.Models;

namespace Tomoyo.Core.Services;

public class LocalProfileStorage : IProfileStorage
{
    public string BaseDirectory { get; }
    
    private const string AvatarDirectory = "avatars";
    private const string CoverDirectory = "covers";
    
    public LocalProfileStorage(string? baseDirectory = null)
    {
        BaseDirectory = baseDirectory ?? CoreSettings.ProfileStorageBaseDirectory;
        // Ensure the directory exists
        if (!Directory.Exists(GetBaseDirectoryFullPath()))
            Directory.CreateDirectory(GetBaseDirectoryFullPath());
    }
    
    public Task<Stream> UploadAvatarAsync(string userId, ProfileType profileType, Stream stream, string contentType, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    
    private string GetBaseDirectoryFullPath() => Path.Combine(BaseDirectory, CoreSettings.ProfileStorageBaseDirectory);
}