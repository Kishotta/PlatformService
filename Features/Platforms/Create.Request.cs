using System.ComponentModel.DataAnnotations;
using MediatR;

namespace PlatformService.Features.Platforms.Create;

public record Request : IRequest<Response>
{
    [Required]
    public string Name { get; init; } = default!;

    [Required]
    public string Publisher { get; init; } = default!;

    [Required]
    public string Cost { get; init; } = default!;
}
