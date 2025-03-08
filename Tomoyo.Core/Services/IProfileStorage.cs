using Tomoyo.Core.Models;

namespace Tomoyo.Core.Services;

public interface IProfileStorage
{
    Task<string> UploadAvatarAsync(string userId, ProfileType profileType, Stream stream, string fileName, CancellationToken cancellationToken = default);
}