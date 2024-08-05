using MediatR;

namespace Motoca.Platform.Domain.Mediator.Commands.Requests;

public class DeleteMotorcycleCommand : IRequest<Unit>
{
    public Guid MotorcycleGuid { get; set; }
    public long AdministratorId { get; set; }
}