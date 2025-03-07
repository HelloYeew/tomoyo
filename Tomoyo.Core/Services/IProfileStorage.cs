using Tomoyo.Core.Models;

namespace Tomoyo.Core.Services;

public interface IProfileStorage
{
    Task<Stream> UploadAvatarAsync(string userId, ProfileType profileType, Stream stream, string contentType, CancellationToken cancellationToken = default);
}