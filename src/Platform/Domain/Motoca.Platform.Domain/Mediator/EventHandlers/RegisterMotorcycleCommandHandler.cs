using MediatR;
using Microsoft.EntityFrameworkCore;
using Motoca.Platform.Domain.Entities;
using Motoca.Platform.Domain.Interfaces.Repositories;
using Motoca.Platform.Domain.Mediator.Commands.Requests;
using Motoca.Platform.Domain.Mediator.Notifications;

namespace Motoca.Platform.Domain.Mediator.EventHandlers;

public class RegisterMotorcycleCommandHandler(
    IMediator mediator,
    IMotorcycleRepository repository,
    IPlatformWriteUnitOfWork writeUnitOfWork
    ) : IRequestHandler<RegisterMotorcycleCommand, Unit>
{
    private readonly DbContext _context = writeUnitOfWork.GetContext();
    
    public async Task<Unit> Handle(RegisterMotorcycleCommand request, CancellationToken cancellationToken)
    {
        var motorcycle = request.ToMotorcycle();
        
        motorcycle.Validate();
        
        var exists = await repository.Exists(motorcycle.LicensePlate);
        
        if (exists)
            throw new Exception("Esta moto já está cadastrada.");
        
        _context.Set<Motorcycle>().Add(motorcycle);
        _context.SaveChanges();
        
        await mediator.Publish(new RegisteredMotorcycleNotification
        {
            Guid = motorcycle.Guid,
            Year = motorcycle.Year,
            Model = motorcycle.Model,
            LicensePlate = motorcycle.LicensePlate
        });

        return Unit.Value;
    }
}