using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PlatformService.Features.Platforms.Create;

[ApiController]
[Route(Routes.Platforms)]
[ApiExplorerSettings(GroupName = "Platforms")]
public class Create : ControllerBase
{
    private readonly IMediator _mediator;

    public Create(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType(typeof(Response), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Response>> HandleAsync([FromBody] Request request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return CreatedAtRoute("GetPlatformById", new { Id = result.Id }, result);
    }
}
