using MediatR;
using Motoca.Platform.Domain.Interfaces.Repositories;
using Motoca.Platform.Domain.Mediator.Commands.Requests;
using Motoca.Platform.Domain.Mediator.Commands.Responses;

namespace Motoca.Platform.Domain.Mediator.EventHandlers;

public class ListPlansCommandHandler(IPlanRepository repository) : IRequestHandler<ListPlansCommand, IEnumerable<PlanResponse>>
{
    public async Task<IEnumerable<PlanResponse>> Handle(ListPlansCommand request, CancellationToken cancellationToken)
    {
        var plans = await repository.GetAll();

        var response = plans.Select(p => new PlanResponse
        {
            Guid = p.Guid,
            CostPerDay = p.CostPerDay,
            TotalDays = p.TotalDays
        });

        return response;
    }
}