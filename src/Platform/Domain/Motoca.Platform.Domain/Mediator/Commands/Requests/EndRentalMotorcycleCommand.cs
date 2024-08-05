using MediatR;
using Motoca.Platform.Domain.Mediator.Commands.Responses;

namespace Motoca.Platform.Domain.Mediator.Commands.Requests;

public class EndRentalMotorcycleCommand : IRequest<EndRentalResponse>
{
    public long DeliverymanId { get; set; }
}