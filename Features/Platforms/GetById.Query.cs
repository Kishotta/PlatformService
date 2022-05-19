using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PlatformService.Features.Platforms.GetById;

public record Query : IRequest<Response> {
    [Required]
    [FromRoute(Name = "id")]
    public int PlatformId { get; init; }
}
