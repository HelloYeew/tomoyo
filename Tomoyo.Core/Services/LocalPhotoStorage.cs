using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using Tomoyo.Core.Configurations;
using Tomoyo.Core.Images;
using Tomoyo.Core.Images.Processor;
using Tomoyo.Core.Utilities;

namespace Tomoyo.Core.Services;

public class LocalPhotoStorage : IPhotoStorage
{
    private string BaseDirectory { get; }
    
    private const string OriginalDirectory = "original";
    private const string ThumbnailDirectory = "thumbnail";

    public LocalPhotoStorage(string? baseDirectory = null)
    {
        BaseDirectory = baseDirectory ?? CoreSettings.PhotoStorageBaseDirectory;
        if (!Directory.Exists(GetBaseDirectoryFullPath()))
            Directory.CreateDirectory(GetBaseDirectoryFullPath());
        if (!Directory.Exists(GetOriginalDirectoryFullPath()))
            Directory.CreateDirectory(GetOriginalDirectoryFullPath());
        if (!Directory.Exists(GetThumbnailDirectoryFullPath()))
            Directory.CreateDirectory(GetThumbnailDirectoryFullPath());
    }
    
    public async Task<UploadPhotoResult> UploadPhotoAsync(string userId, int photoId, Stream stream, string fileName,
        CancellationToken cancellationToken = default)
    {
        string newOriginalFilename = FileHelper.GenerateNewPhotoDataFileName(userId, photoId, FileHelper.PhotoDataType.Original, fileName);
        string newThumbnailFilename = FileHelper.GenerateNewPhotoDataFileName(userId, photoId, FileHelper.PhotoDataType.Thumbnail, fileName);
        
        // Will save an original and watermarked as JPEG and thumbnail as WEBP
        newOriginalFilename = Path.ChangeExtension(newOriginalFilename, ".jpg");
        newThumbnailFilename = Path.ChangeExtension(newThumbnailFilename, ".webp");

        using (Image image = await Image.LoadAsync(stream, cancellationToken))
        {
            // Resize full image -> size that we want
            image.ResizePhoto();
            await image.SaveAsJpegAsync(newOriginalFilename, new JpegEncoder { Quality = ProcessorConstant.PhotoOriginalMaxJpegQuality }, cancellationToken);
            
            // TODO: Save thumbnail and watermarked
        }

        return new UploadPhotoResult()
        {
            FileName = fileName,
            OriginalFileName = newOriginalFilename,
            ThumbnailFileName = newThumbnailFilename,
        };
    }
    
    private string GetBaseDirectoryFullPath() => Path.Combine(BaseDirectory);
    private string GetOriginalDirectoryFullPath() => Path.Combine(GetBaseDirectoryFullPath(), OriginalDirectory);
    private string GetThumbnailDirectoryFullPath() => Path.Combine(GetBaseDirectoryFullPath(), ThumbnailDirectory);
}