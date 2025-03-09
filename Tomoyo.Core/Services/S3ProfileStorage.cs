namespace Tomoyo.Core.Services;

public class S3ProfileStorage : IProfileStorage
{
    public async Task<string> UploadAvatarAsync(string userId, Stream stream, string fileName, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<GetAvatarResult> GetAvatarAsync(string userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}