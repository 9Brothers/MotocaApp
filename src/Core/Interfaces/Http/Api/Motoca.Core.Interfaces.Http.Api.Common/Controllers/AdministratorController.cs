using MediatR;
using Microsoft.AspNetCore.Mvc;
using Motoca.Core.Domain.Mediator.Commands.Requests;

namespace Motoca.Interfaces.Http.Api.Common.Controllers;

[ApiController]
[Route("administrator")]
public class AdministratorController(IMediator mediator) : CoreController
{
    [HttpPost]
    public async Task<IActionResult> Add(CreateAdministratorCommand request)
    {
        await mediator.Send(request);

        return Created();
    }
}