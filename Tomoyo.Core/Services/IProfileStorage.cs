namespace Tomoyo.Core.Services;

public interface IProfileStorage
{
    Task<string> UploadAvatarAsync(string userId, Stream stream, string fileName, CancellationToken cancellationToken = default);
    
    Task<GetAvatarResult> GetAvatarAsync(string userId, CancellationToken cancellationToken = default);
}