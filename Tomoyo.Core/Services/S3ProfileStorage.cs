using Tomoyo.Core.Models;

namespace Tomoyo.Core.Services;

public class S3ProfileStorage : IProfileStorage
{
    public async Task<string> UploadAvatarAsync(string userId, ProfileType profileType, Stream stream, string fileName, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<GetAvatarResult> GetAvatarAsync(string userId, ProfileType profileType, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}