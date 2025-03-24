using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Tomoyo.Core.Images.Processor;

public static class PhotoProcessor
{
    /// <summary>
    /// Resize an image by using max width and height
    /// </summary>
    /// <param name="image">ImageSharp <see cref="Image"/></param>
    /// <param name="maxWidth">Max width, default to <see cref="ProcessorConstant"/></param>
    /// <param name="maxHeight">Max height, default to <see cref="ProcessorConstant"/></param>
    public static void ResizePhoto(this Image image, int maxWidth = ProcessorConstant.PhotoOriginalMaxWidth, int maxHeight = ProcessorConstant.PhotoOriginalMaxHeight)
    {
        image.Mutate(x => x.Resize(new ResizeOptions
        {
            Size = new Size(maxWidth, maxHeight),
            Mode = ResizeMode.Max
        }));
    }
    
    /// <summary>
    /// Resize an image to be square and crop as thumbnail (centered)
    /// </summary>
    /// <param name="image">ImageSharp <see cref="Image"/></param>
    /// <param name="size">Target size, default to <see cref="ProcessorConstant"/></param>
    public static void ResizeThumbnail(this Image image, int size = ProcessorConstant.PhotoThumbnailSize)
    {
        image.Mutate(x => x.Resize(new ResizeOptions
        {
            Size = new Size(size, size),
            Mode = ResizeMode.Crop,
            Position = AnchorPositionMode.Center
        }));
    }
}