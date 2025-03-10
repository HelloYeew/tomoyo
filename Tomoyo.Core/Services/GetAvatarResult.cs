namespace Tomoyo.Core.Services;

public record GetAvatarResult
{
    public byte[]? Avatar { get; set; }
    public string? FileName { get; set; }
}