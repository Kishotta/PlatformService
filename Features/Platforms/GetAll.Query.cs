using MediatR;

namespace PlatformService.Features.Platforms.GetAll;

public record Query : IRequest<IEnumerable<Response>>
{
}
