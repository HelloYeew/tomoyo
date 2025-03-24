namespace Tomoyo.Core.Services;

public class S3PhotoStorage : IPhotoStorage
{
    public Task<UploadPhotoResult> UploadPhotoAsync(string userId, int photoId, Stream stream, string fileName,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<GetPhotoResult> GetPhotoAsync(int photoId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}