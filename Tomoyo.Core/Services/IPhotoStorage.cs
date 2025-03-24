namespace Tomoyo.Core.Services;

public interface IPhotoStorage
{
    Task<UploadPhotoResult> UploadPhotoAsync(string userId, int photoId, Stream stream, string fileName, CancellationToken cancellationToken = default);
    
    Task<GetPhotoResult> GetPhotoAsync(int photoId, CancellationToken cancellationToken = default);
}