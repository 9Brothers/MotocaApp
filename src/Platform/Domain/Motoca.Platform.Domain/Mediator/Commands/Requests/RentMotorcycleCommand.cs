using MediatR;
using Motoca.Platform.Domain.Mediator.Commands.Responses;

namespace Motoca.Platform.Domain.Mediator.Commands.Requests;

public class RentMotorcycleCommand : IRequest<RentalResponse>
{
    public DateTime Start { get; set; }
    public Guid PlanGuid { get; set; }
    public long? DeliverymanId { get; set; }
}