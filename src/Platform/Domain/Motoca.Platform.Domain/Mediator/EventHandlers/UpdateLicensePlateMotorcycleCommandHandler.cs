using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Motoca.Platform.Domain.Entities;
using Motoca.Platform.Domain.Interfaces.Repositories;
using Motoca.Platform.Domain.Mediator.Commands.Requests;

namespace Motoca.Platform.Domain.Mediator.EventHandlers;

public class UpdateLicensePlateMotorcycleCommandHandler(
    ILogger<UpdateLicensePlateMotorcycleCommandHandler> logger,
    IMotorcycleRepository motorcycleRepository,
    IPlatformWriteUnitOfWork uow
    ) : IRequestHandler<UpdateLicensePlateMotorcycleCommand, Unit>
{
    private readonly DbContext context = uow.GetContext();
    
    public async Task<Unit> Handle(UpdateLicensePlateMotorcycleCommand request, CancellationToken cancellationToken)
    {
        var motorcycle = await motorcycleRepository.GetByLicensePlate(request.WrongLicensePlate);

        if (motorcycle is null)
            throw new Exception("Motoca não encontrada.");

        motorcycle.LicensePlate = request.CorrectLicensePlate;
        motorcycle.UpdatedBy = request.AdministratorId.Value;
        motorcycle.UpdatedAt = DateTime.UtcNow;

        context.Set<Motorcycle>().Update(motorcycle);
        context.SaveChanges();
        
        return Unit.Value;
    }
}