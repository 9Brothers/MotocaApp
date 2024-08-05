using MediatR;
using Microsoft.AspNetCore.Mvc;
using Motoca.Core.Domain.Mediator.Commands.Requests;

namespace Motoca.Interfaces.Http.Api.Common.Controllers;

[ApiController]
[Route("auth")]
public class AuthController(IMediator mediator) : CoreController
{
    [HttpPost("administrator")]
    public async Task<IActionResult> LoginAdministrator(AuthenticateAdministratorCommand command)
    {
        var token = await mediator.Send(command);

        return Ok(token);
    }
}