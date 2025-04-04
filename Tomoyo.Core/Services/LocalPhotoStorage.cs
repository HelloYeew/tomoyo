using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Webp;
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
        string newOriginalFilename = FileHelper.GenerateNewPhotoDataFileName(photoId, FileHelper.PhotoDataType.Original, fileName);
        string newThumbnailFilename = FileHelper.GenerateNewPhotoDataFileName(photoId, FileHelper.PhotoDataType.Thumbnail, fileName);
        
        // Will save an original and watermarked as JPEG and thumbnail as WEBP
        newOriginalFilename = Path.ChangeExtension(newOriginalFilename, ".jpg");
        newThumbnailFilename = Path.ChangeExtension(newThumbnailFilename, ".webp");

        using (Image image = await Image.LoadAsync(stream, cancellationToken))
        {
            // Resize full image -> size that we want
            image.ResizePhoto();
            await image.SaveAsJpegAsync(Path.Combine(GetOriginalDirectoryFullPath(), newOriginalFilename), new JpegEncoder { Quality = ProcessorConstant.PhotoOriginalEncoderQuality }, cancellationToken);
            
            image.ResizeThumbnail();
            await image.SaveAsWebpAsync(Path.Combine(GetThumbnailDirectoryFullPath(), newThumbnailFilename), new WebpEncoder { Quality = ProcessorConstant.PhotoThumbnaildEncoderQuality }, cancellationToken);
        }

        return new UploadPhotoResult()
        {
            FileName = fileName,
            OriginalFileName = newOriginalFilename,
            ThumbnailFileName = newThumbnailFilename
        };
    }

    public async Task<GetPhotoResult> GetPhotoAsync(int photoId, CancellationToken cancellationToken = default)
    {
        string[] files = Directory.GetFiles(GetOriginalDirectoryFullPath(),
            FileHelper.GenerateNewPhotoDataFileName(photoId, FileHelper.PhotoDataType.Original));

        return files.Length == 0
            ? new GetPhotoResult()
            {
                Photo = new byte[0],
                FileName = ""
            }
            : new GetPhotoResult()
            {
                Photo = await File.ReadAllBytesAsync(files[0], cancellationToken),
                FileName = Path.GetFileName(files[0])
            };
    }

    private string GetBaseDirectoryFullPath() => Path.Combine(BaseDirectory);
    private string GetOriginalDirectoryFullPath() => Path.Combine(GetBaseDirectoryFullPath(), OriginalDirectory);
    private string GetThumbnailDirectoryFullPath() => Path.Combine(GetBaseDirectoryFullPath(), ThumbnailDirectory);
}