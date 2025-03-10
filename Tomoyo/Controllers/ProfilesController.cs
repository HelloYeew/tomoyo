using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Tomoyo.Core.Services;

namespace Tomoyo.Controllers;

[Route("api/profiles")]
[ApiController]
public class ProfilesController : ControllerBase
{
    private readonly IProfileStorage _profileStorage;
        
    public ProfilesController(IProfileStorage profileStorage)
    {
        _profileStorage = profileStorage;
    }
    
    [HttpGet("avatar/{userId}")]
    public async Task<IActionResult> GetAvatar(string userId, CancellationToken cancellationToken)
    {
        GetAvatarResult avatar = await _profileStorage.GetAvatarAsync(userId, cancellationToken);
        if (avatar.FileName == "" || avatar.Avatar == null)
        {
            return new NotFoundResult();
        }
        ContentDisposition cd = new ContentDisposition
        {
            FileName = avatar.FileName,
            Inline = true
        };
        Response.Headers.Append("Content-Disposition", cd.ToString());
        return new FileContentResult(avatar.Avatar, MimeMapping.MimeUtility.GetMimeMapping(avatar.FileName ?? ""));
    }
    
    [HttpGet("cover/{userId}")]
    public async Task<IActionResult> GetCover(string userId, CancellationToken cancellationToken)
    {
        GetCoverResult cover = await _profileStorage.GetCoverAsync(userId, cancellationToken);
        if (cover.FileName == "" || cover.Cover == null)
        {
            return new NotFoundResult();
        }
        ContentDisposition cd = new ContentDisposition
        {
            FileName = cover.FileName,
            Inline = true
        };
        Response.Headers.Append("Content-Disposition", cd.ToString());
        return new FileContentResult(cover.Cover, MimeMapping.MimeUtility.GetMimeMapping(cover.FileName ?? ""));
    }
}