using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Tomoyo.Core.Images.Processor;

public static class CoverProcessor
{
    /// <summary>
    /// Resize an image to be cover (centered)
    /// </summary>
    /// <param name="image">ImageSharp <see cref="Image"/></param>
    /// <param name="width">Image width</param>
    /// <param name="height">Image height</param>
    public static void ResizeCover(this Image image, int width = ProcessorConstant.CoverWidth,
        int height = ProcessorConstant.CoverHeight)
    {
        image.Mutate(x => x.Resize(new ResizeOptions
        {
            Size = new Size(width, height),
            Mode = ResizeMode.Crop,
            Position = AnchorPositionMode.Center
        }));
    }
}