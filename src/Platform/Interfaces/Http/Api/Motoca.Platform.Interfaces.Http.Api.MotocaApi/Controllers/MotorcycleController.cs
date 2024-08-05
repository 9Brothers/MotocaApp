using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Motoca.Interfaces.Http.Api.Common.Controllers;
using Motoca.Platform.Domain.Mediator.Commands.Requests;

namespace Motoca.Interfaces.Http.Api.MotocaApi.Controllers;

[ApiController]
[Route("motorcycle")]
public class MotorcycleController(IMediator mediator) : CoreController
{
    [Authorize("Administrator")]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] RegisterMotorcycleCommand command)
    {
        command.AdministratorId = GetAdministradorId();
        
        await mediator.Send(command);
        
        return Ok();
    }
    
    [Authorize("Administrator")]
    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery(Name = "licensePlate")] string? licencePlate,
        [FromQuery(Name = "page")] int page
        )
    {
        ListMotorcycleCommand command = new()
        {
            LicensePlate = licencePlate,
            Page = page
        };
        
        var motorcycles = await mediator.Send(command);
        
        return Ok(motorcycles);
    }
    
    [Authorize("Administrator")]
    [HttpPut]
    public async Task<IActionResult> UpdateLicensePlate([FromBody] UpdateLicensePlateMotorcycleCommand command)
    {
        command.AdministratorId = GetAdministradorId();
        
        await mediator.Send(command);
        
        return Ok();
    }
    
    [Authorize("Administrator")]
    [HttpDelete("{motorcycleGuid:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid motorcycleGuid)
    {
        var command = new DeleteMotorcycleCommand
        {
            AdministratorId = GetAdministradorId(),
            MotorcycleGuid = motorcycleGuid
        };
        
        await mediator.Send(command);
        
        return Ok();
    }
}