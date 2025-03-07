using Tomoyo.Core.Models;

namespace Tomoyo.Core.Services;

public interface IProfileStorage
{
    Task<string> UploadAvatarAsync(string userId, ProfileType profileType, byte[] file, string fileName, CancellationToken cancellationToken = default);
}