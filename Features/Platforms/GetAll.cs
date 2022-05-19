using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PlatformService.Features.Platforms.GetAll;

[ApiController]
[Route(Routes.Platforms)]
[ApiExplorerSettings(GroupName = "Platforms")]
public class GetAll : ControllerBase
{
    private readonly IMediator _mediator;

    public GetAll(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<Response>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Response>>> HandleAsync(CancellationToken cancellationToken)
    {
        var query = new Query();
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
}
