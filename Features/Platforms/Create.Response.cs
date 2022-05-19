namespace PlatformService.Features.Platforms.Create;

public record Response
{
    public int Id { get; init; }
    public string Name { get; init; } = default!;
    public string Publisher { get; init; } = default!;
    public string Cost { get; init; } = default!;
}
