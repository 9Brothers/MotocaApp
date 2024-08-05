using MediatR;
using Motoca.Platform.Domain.Mediator.Commands.Responses;

namespace Motoca.Platform.Domain.Mediator.Commands.Requests;

public class ListMotorcycleCommand : IRequest<IEnumerable<MotorcycleResponse>>
{
    public string LicensePlate { get; set; }
    public int Page { get; set; }
}