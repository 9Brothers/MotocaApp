using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Motoca.Interfaces.Http.Api.Common.Controllers;
using Motoca.Platform.Domain.Mediator.Commands.Requests;

namespace Motoca.Interfaces.Http.Api.MotocaApi.Controllers;

[ApiController]
[Route("rental")]
public class RentalController(IMediator mediator) : CoreController
{
    [Authorize("Deliveryman")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RentMotorcycleCommand command)
    {
        command.DeliverymanId = GetDeliverymanId();
        
        var response = await mediator.Send(command);
        
        return Ok(response);
    }
    
    [Authorize("Deliveryman")]
    [HttpPost("end")]
    public async Task<IActionResult> End()
    {
        var command = new EndRentalMotorcycleCommand
        {
            DeliverymanId = GetDeliverymanId(),
        };
        
        var response = await mediator.Send(command);
        
        return Ok(response);
    }
}