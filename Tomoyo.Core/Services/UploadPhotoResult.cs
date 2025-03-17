namespace Tomoyo.Core.Services;

public record UploadPhotoResult()
{
    public string FileName { get; init; }
    public string OriginalFileName { get; init; }
    public string ThumbnailFileName { get; init; }
    public string WatermarkedFileName { get; init; }
};