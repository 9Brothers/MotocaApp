using MediatR;
using Microsoft.EntityFrameworkCore;
using Motoca.Platform.Domain.Entities;
using Motoca.Platform.Domain.Interfaces.Repositories;
using Motoca.Platform.Domain.Mediator.Commands.Requests;
using Motoca.Platform.Domain.Mediator.Commands.Responses;

namespace Motoca.Platform.Domain.Mediator.EventHandlers;

public class EndRentalMotorcycleCommandHandler(
    IRentalRepository rentalRepository,
    IPlanRepository planRepository,
    IMotorcycleRepository motorcycleRepository,
    IPlatformWriteUnitOfWork uow
    ) : IRequestHandler<EndRentalMotorcycleCommand, EndRentalResponse>
{
    private readonly DbContext context = uow.GetContext();
    
    public async Task<EndRentalResponse> Handle(EndRentalMotorcycleCommand request, CancellationToken cancellationToken)
    {
        // Buscar aluguel
        var rental = await rentalRepository.OpenByDeliverymanId(request.DeliverymanId);

        if (rental is null)
            throw new Exception("Você não tem nenhum aluguel em aberto");
        
        rental.End = DateTime.Now;
        
        // Buscar plano
        var plan = await planRepository.GetById(rental.PlanId);

        // Se data final menor do que a prevista, efetuar calculos com base nos planos
        var remainingDays = Math.Abs(rental.ExpectedEnd.Date.Subtract(rental.End.Value.Date).Days);

        if (remainingDays > plan.TotalDays)
            remainingDays = plan.TotalDays;
        
        if (rental.End < rental.ExpectedEnd)
            rental.Fee = plan.CostPerDay * remainingDays * plan.Fee;

        // Se data final maior do que a prevista, cobrar R$ 50 por diária adicional
        if (rental.End > rental.ExpectedEnd)
            rental.Fee = remainingDays * 50;
        
        // Buscar moto e setar como disponível
        var motorcycle = await motorcycleRepository.GetById(rental.MotorcycleId);
        motorcycle.Available = true;

        context.Set<Motorcycle>().Update(motorcycle);
        context.Set<Rental>().Update(rental);
        context.SaveChanges();
        
        // Compor response
        return new EndRentalResponse
        {
            Fee = rental.Fee
        };
    }
}