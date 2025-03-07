using Tomoyo.Core.Models;

namespace Tomoyo.Core.Services;

public class S3ProfileStorage : IProfileStorage
{
    public Task<Stream> UploadAvatarAsync(string userId, ProfileType profileType, Stream stream, string contentType, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}