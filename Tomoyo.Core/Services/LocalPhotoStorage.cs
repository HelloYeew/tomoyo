using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using Tomoyo.Core.Configurations;
using Tomoyo.Core.Images;
using Tomoyo.Core.Images.Processor;
using Tomoyo.Core.Utilities;

namespace Tomoyo.Core.Services;

public class LocalPhotoStorage : IPhotoStorage
{
    public string BaseDirectory { get; }
    
    private const string OriginalDirectory = "original";
    private const string ThumbnailDirectory = "thumbnail";
    private const string WatermarkedDirectory = "watermarked";

    public LocalPhotoStorage(string? baseDirectory = null)
    {
        BaseDirectory = baseDirectory ?? CoreSettings.PhotoStorageBaseDirectory;
        if (!Directory.Exists(GetBaseDirectoryFullPath()))
            Directory.CreateDirectory(GetBaseDirectoryFullPath());
        if (!Directory.Exists(GetOriginalDirectoryFullPath()))
            Directory.CreateDirectory(GetOriginalDirectoryFullPath());
        if (!Directory.Exists(GetThumbnailDirectoryFullPath()))
            Directory.CreateDirectory(GetThumbnailDirectoryFullPath());
        if (!Directory.Exists(GetWatermarkedDirectoryFullPath()))
            Directory.CreateDirectory(GetWatermarkedDirectoryFullPath());
    }
    
    public async Task<UploadPhotoResult> UploadPhotoAsync(string userId, int photoId, Stream stream, string fileName,
        CancellationToken cancellationToken = default)
    {
        string newOriginalFilename = FileHelper.GenerateNewPhotoDataFileName(userId, photoId, FileHelper.PhotoDataType.Original, fileName);
        string newThumbnailFilename = FileHelper.GenerateNewPhotoDataFileName(userId, photoId, FileHelper.PhotoDataType.Thumbnail, fileName);
        string newWatermarkedFilename = FileHelper.GenerateNewPhotoDataFileName(userId, photoId, FileHelper.PhotoDataType.Watermarked, fileName);
        
        // Will save an original and watermarked as JPEG and thumbnail as WEBP
        newOriginalFilename = Path.ChangeExtension(newOriginalFilename, ".jpg");
        newThumbnailFilename = Path.ChangeExtension(newThumbnailFilename, ".webp");
        newWatermarkedFilename = Path.ChangeExtension(newWatermarkedFilename, ".jpg");

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
            WatermarkedFileName = newWatermarkedFilename
        };
    }
    
    private string GetBaseDirectoryFullPath() => Path.Combine(BaseDirectory);
    private string GetOriginalDirectoryFullPath() => Path.Combine(GetBaseDirectoryFullPath(), OriginalDirectory);
    private string GetThumbnailDirectoryFullPath() => Path.Combine(GetBaseDirectoryFullPath(), ThumbnailDirectory);
    private string GetWatermarkedDirectoryFullPath() => Path.Combine(GetBaseDirectoryFullPath(), WatermarkedDirectory);
}