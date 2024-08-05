using MediatR;
using Microsoft.EntityFrameworkCore;
using Motoca.Core.Domain.Utils;
using Motoca.Platform.Domain.Entities;
using Motoca.Platform.Domain.Interfaces.Repositories;
using Motoca.Platform.Domain.Mediator.Commands.Requests;
using SixLabors.ImageSharp;

namespace Motoca.Platform.Domain.Mediator.EventHandlers;

public class UploadDeliverymanCnhCommandHandler(
    IDeliverymanRepository deliverymanRepository,
    IPlatformWriteUnitOfWork coreWriteUoW
    ) : IRequestHandler<UploadDeliverymanCnhCommand, Unit>
{
    private readonly DbContext context = coreWriteUoW.GetContext();
    
    public async Task<Unit> Handle(UploadDeliverymanCnhCommand request, CancellationToken cancellationToken)
    {
        var deliveryman = await deliverymanRepository.FindById(request.DeliverymanId);
        
        var storagePhysicalPath = EnvironmentUtils.TryGetEnvironmentVariable("STORAGE_PHYSICAL_PATH");
        var storageVirtualPath = EnvironmentUtils.TryGetEnvironmentVariable("STORAGE_VIRTUAL_PATH");

        Directory.CreateDirectory(storagePhysicalPath);
        
        var image = Image.Load(request.Buffer);

        var physicalPath = $"{storagePhysicalPath}/{deliveryman.Guid}.png";
        var virtualPath = $"{storageVirtualPath}/{deliveryman.Guid}.png";
        
        await image.SaveAsPngAsync(physicalPath);

        deliveryman.CnhUrl = virtualPath;

        context.Set<Deliveryman>().Update(deliveryman);
        context.SaveChanges();
        
        return Unit.Value;
    }
}