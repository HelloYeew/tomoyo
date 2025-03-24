using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Tomoyo.Core.Services;

namespace Tomoyo.Controllers;

[Route("api/photos")]
[ApiController]
public class PhotoController : ControllerBase
{
    private readonly IPhotoStorage _photoStorage;
    
    public PhotoController(IPhotoStorage photoStorage)
    {
        _photoStorage = photoStorage;
    }

    [HttpGet("{photoId}")]
    public async Task<IActionResult> Get(string photoId, CancellationToken cancellationToken)
    {
        if (!int.TryParse(photoId, out _))
        {
            return new NotFoundResult();
        }
        GetPhotoResult photo = await _photoStorage.GetPhotoAsync(int.Parse(photoId), cancellationToken);
        if (photo.FileName == "" || photo.Photo == null)
        {
            return new NotFoundResult();
        }
        ContentDisposition cd = new ContentDisposition
        {
            FileName = photo.FileName,
            Inline = true
        };
        Response.Headers.Append("Content-Disposition", cd.ToString());
        return new FileContentResult(photo.Photo, MimeMapping.MimeUtility.GetMimeMapping(photo.FileName ?? ""));
    }
}