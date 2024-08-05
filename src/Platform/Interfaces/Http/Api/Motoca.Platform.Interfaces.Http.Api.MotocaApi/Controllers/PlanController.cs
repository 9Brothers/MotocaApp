using MediatR;
using Microsoft.AspNetCore.Mvc;
using Motoca.Interfaces.Http.Api.Common.Controllers;
using Motoca.Platform.Domain.Mediator.Commands.Requests;

namespace Motoca.Interfaces.Http.Api.MotocaApi.Controllers;

[ApiController]
[Route("plan")]
public class PlanController(IMediator mediator) : CoreController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var plans = await mediator.Send(new ListPlansCommand());

        return Ok(plans);
    }
}