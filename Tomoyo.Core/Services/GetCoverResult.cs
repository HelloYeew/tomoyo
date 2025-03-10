namespace Tomoyo.Core.Services;

public record GetCoverResult
{
    public byte[]? Cover { get; set; }
    public string? FileName { get; set; }
}