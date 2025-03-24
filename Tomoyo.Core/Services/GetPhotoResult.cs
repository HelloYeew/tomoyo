namespace Tomoyo.Core.Services;

public record GetPhotoResult()
{
    public byte[]? Photo { get; init; }
    public string? FileName { get; init; }
}