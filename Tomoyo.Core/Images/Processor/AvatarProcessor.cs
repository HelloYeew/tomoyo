using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Tomoyo.Core.Images.Processor;

public static class AvatarProcessor
{
    /// <summary>
    /// Resize an image to be square and crop as avatar (centered)
    /// </summary>
    /// <param name="image">ImageSharp <see cref="Image"/></param>
    /// <param name="size">Target size</param>
    public static void ResizeAvatar(this Image image, int size = ProcessorConstant.AvatarSize)
    {
        image.Mutate(x => x.Resize(new ResizeOptions
        {
            Size = new Size(size, size),
            Mode = ResizeMode.Crop,
            Position = AnchorPositionMode.Center
        }));
    }
}