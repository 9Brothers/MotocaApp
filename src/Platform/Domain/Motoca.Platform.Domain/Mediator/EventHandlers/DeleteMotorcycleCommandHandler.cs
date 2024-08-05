using MediatR;
using Microsoft.EntityFrameworkCore;
using Motoca.Platform.Domain.Entities;
using Motoca.Platform.Domain.Interfaces.Repositories;
using Motoca.Platform.Domain.Mediator.Commands.Requests;

namespace Motoca.Platform.Domain.Mediator.EventHandlers;

public class DeleteMotorcycleCommandHandler(
    IMotorcycleRepository motorcycleRepository,
    IRentalRepository rentalRepository,
    IPlatformWriteUnitOfWork uow
    ) : IRequestHandler<DeleteMotorcycleCommand, Unit>
{
    private readonly DbContext context = uow.GetContext();
    
    public async Task<Unit> Handle(DeleteMotorcycleCommand request, CancellationToken cancellationToken)
    {
        var motorcycle = await motorcycleRepository.GetByGuid(request.MotorcycleGuid);

        var existsRental = await rentalRepository.ExistsByMotorcycleId(motorcycle.Id);

        if (existsRental)
            throw new Exception("Não é possível remover o cadastro dessa motoca, já existem locações efetuadas.");

        context.Set<Motorcycle>().Remove(motorcycle);
        context.SaveChanges();
        
        return Unit.Value;
    }
}