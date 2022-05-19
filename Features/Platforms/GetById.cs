using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PlatformService.Features.Platforms.GetById;

[ApiController]
[Route(Routes.Platforms)]
[ApiExplorerSettings(GroupName = "Platforms")]
public class GetById : ControllerBase
{
    private readonly IMediator _mediator;

    public GetById(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:int}", Name = "GetPlatformById")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Response>> HandleAsync([FromQuery] Query query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return result != null ? Ok(result) : NotFound();
    }
}
