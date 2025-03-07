using Tomoyo.Core.Models;

namespace Tomoyo.Core.Services;

public class S3ProfileStorage : IProfileStorage
{
    public Task<string> UploadAvatarAsync(string userId, ProfileType profileType, byte[] file, string fileName, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}