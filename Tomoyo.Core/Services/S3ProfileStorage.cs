namespace Tomoyo.Core.Services;

public class S3ProfileStorage : IProfileStorage
{
    public Task<string> UploadAvatarAsync(string userId, Stream stream, string fileName, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<string> UploadCoverAsync(string userId, Stream stream, string fileName, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<GetAvatarResult> GetAvatarAsync(string userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<GetCoverResult> GetCoverAsync(string userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}