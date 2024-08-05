using MediatR;
using Microsoft.AspNetCore.Mvc;
using Motoca.Interfaces.Http.Api.Common.Controllers;
using Motoca.Platform.Domain.Mediator.Commands.Requests;

namespace Motoca.Interfaces.Http.Api.MotocaApi.Controllers;

[ApiController]
[Route("auth")]
public class AuthController(IMediator mediator) : CoreController
{
    [HttpPost]
    public async Task<IActionResult> LoginDeliveryman(AuthenticateDeliverymanCommand command)
    {
        var token = await mediator.Send(command);

        return Ok(token);
    }
}