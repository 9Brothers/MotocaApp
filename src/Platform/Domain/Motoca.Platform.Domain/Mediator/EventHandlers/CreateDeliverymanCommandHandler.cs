using MediatR;
using Microsoft.EntityFrameworkCore;
using Motoca.Platform.Domain.Entities;
using Motoca.Platform.Domain.Interfaces.Repositories;
using Motoca.Platform.Domain.Mediator.Commands.Requests;
using Motoca.Platform.Domain.Mediator.NotificationHandlers;

namespace Motoca.Platform.Domain.Mediator.EventHandlers;

public class CreateDeliverymanCommandHandler(
    IPlatformWriteUnitOfWork coreWriteUoW,
    IDeliverymanRepository deliverymanRepository,
    IMediator mediator)
    : IRequestHandler<CreateDeliverymanCommand, Unit>
{
    private readonly DbContext _writeContext = coreWriteUoW.GetContext();

    public async Task<Unit> Handle(CreateDeliverymanCommand request, CancellationToken cancellationToken)
    {
        var deliveryman = request.ToDeliveryman();
        
        deliveryman.Validate();

        var exists = await deliverymanRepository.ExistsCNPJ(deliveryman.CNPJ);

        if (exists)
            throw new Exception("Este CNPJ já está cadastrado.");

        _writeContext.Set<Deliveryman>().Add(deliveryman);
        _writeContext.SaveChanges();

        await mediator.Publish(new CreatedDeliverymanNotification
        {
            CNPJ = deliveryman.CNPJ,
            Name = deliveryman.Name
        });
        
        return Unit.Value;
    }
}