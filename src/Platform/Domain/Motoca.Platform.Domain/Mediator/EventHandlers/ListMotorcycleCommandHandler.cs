using MediatR;
using Motoca.Platform.Domain.Interfaces.Repositories;
using Motoca.Platform.Domain.Mediator.Commands.Requests;
using Motoca.Platform.Domain.Mediator.Commands.Responses;

namespace Motoca.Platform.Domain.Mediator.EventHandlers;

public class ListMotorcycleCommandHandler(IMotorcycleRepository repository) : IRequestHandler<ListMotorcycleCommand, IEnumerable<MotorcycleResponse>>
{
    public async Task<IEnumerable<MotorcycleResponse>> Handle(ListMotorcycleCommand request, CancellationToken cancellationToken)
    {
        return await repository.GetAllByLicensePlate(request.LicensePlate, request.Page);
    }
}