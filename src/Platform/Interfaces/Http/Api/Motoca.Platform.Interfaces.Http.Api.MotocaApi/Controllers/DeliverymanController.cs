using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Motoca.Interfaces.Http.Api.Common.Controllers;
using Motoca.Platform.Domain.Mediator.Commands.Requests;

namespace Motoca.Interfaces.Http.Api.MotocaApi.Controllers;

[ApiController]
[Route("deliveryman")]
public class DeliverymanController(IMediator mediator) : CoreController
{
    [HttpPost]
    public async Task<IActionResult> Add(CreateDeliverymanCommand request)
    {
        await mediator.Send(request);

        return Created();
    }
    
    [Authorize("Deliveryman")]
    [HttpPut("upload/cnh")]
    public async Task<IActionResult> UploadCNH([FromForm] IFormFile file)
    {
        var allowedFormats = new[] { "png", "bmp" };

        var fileExtension = file.FileName.Split(".").LastOrDefault();

        if (string.IsNullOrEmpty(fileExtension))
            return BadRequest(new {message = "Não foi encontrado a extensão desse arquivo."});
        
        if (!allowedFormats.Contains(fileExtension))
            return BadRequest(new {message = "Formato de arquivo não suportado."});
        
        using var memoryStream = new MemoryStream();

        await file.CopyToAsync(memoryStream);

        await mediator.Send(new UploadDeliverymanCnhCommand
        {
            DeliverymanId = GetDeliverymanId(),
            Buffer = memoryStream.GetBuffer()
        });

        return Created();
    }
}