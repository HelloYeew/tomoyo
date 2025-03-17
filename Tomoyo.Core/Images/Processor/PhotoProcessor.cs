using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Tomoyo.Core.Images.Processor;

public static class PhotoProcessor
{
    /// <summary>
    /// Resize an image by using max width and height
    /// </summary>
    /// <param name="image">ImageSharp <see cref="Image"/></param>
    /// <param name="maxWidth">Max width</param>
    /// <param name="maxHeight">Max height</param>
    public static void ResizePhoto(this Image image, int maxWidth = ProcessorConstant.PhotoMaxWidth, int maxHeight = ProcessorConstant.PhotoMaxHeight)
    {
        image.Mutate(x => x.Resize(new ResizeOptions
        {
            Size = new Size(maxWidth, maxHeight),
            Mode = ResizeMode.Max
        }));
    }
}