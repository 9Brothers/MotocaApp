using MediatR;
using Microsoft.EntityFrameworkCore;
using Motoca.Platform.Domain.Entities;
using Motoca.Platform.Domain.Interfaces.Repositories;
using Motoca.Platform.Domain.Mediator.Commands.Requests;
using Motoca.Platform.Domain.Mediator.Commands.Responses;

namespace Motoca.Platform.Domain.Mediator.EventHandlers;

public class RentMotorcycleCommandHandler(
    IMotorcycleRepository motorcycleRepository,
    IDeliverymanRepository deliverymanRepository,
    IRentalRepository rentalRepository,
    IPlanRepository planRepository,
    IPlatformWriteUnitOfWork uow) : IRequestHandler<RentMotorcycleCommand, RentalResponse>
{
    private readonly DbContext context = uow.GetContext();
    
    public async Task<RentalResponse> Handle(RentMotorcycleCommand request, CancellationToken cancellationToken)
    {
        var deliveryman = await deliverymanRepository.FindById(request.DeliverymanId.Value);
        
        var existOpenRent = await rentalRepository.ExistsOpenByDeliverymanId(request.DeliverymanId);

        if (existOpenRent)
            throw new Exception("Você já possui em aluguel em aberto.");

        if (!deliveryman.CnhType.Contains("A"))
            throw new Exception("Para alugar uma motoca é necessário que você possua uma habilitação contendo a categoria A.");
        
        var motorcycle = await motorcycleRepository.FirstAvailable();

        if (motorcycle is null)
            throw new Exception("Desculpe, no momento não temos motocas disponíveis.");
        
        motorcycle.Available = false;
        
        var plan = await planRepository.GetByGuid(request.PlanGuid);
        
        if (plan is null)
            throw new Exception("Desculpe, no momento não temos planos disponíveis.");

        if (request.Start.Date <= DateTime.Today.Date)
            request.Start = DateTime.Today.AddDays(1);
        
        var rental = new Rental()
        {
            Start = request.Start,
            ExpectedEnd = request.Start.AddDays(plan.TotalDays),
            DeliverymanId = request.DeliverymanId.Value,
            MotorcycleId = motorcycle.Id,
            PlanId = plan.Id
        };

        context.Set<Rental>().Add(rental);
        context.Set<Motorcycle>().Update(motorcycle);
        context.SaveChanges();

        return new RentalResponse
        {
            Model = motorcycle.Model,
            LicensePlate = motorcycle.LicensePlate,
            Year = motorcycle.Year,
            MotorcycleGuid = motorcycle.Guid,
            RentalGuid = rental.Guid 
        };
    }
}