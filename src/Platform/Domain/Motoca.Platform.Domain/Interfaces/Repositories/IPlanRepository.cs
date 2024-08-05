using Motoca.Platform.Domain.Entities;

namespace Motoca.Platform.Domain.Interfaces.Repositories;

public interface IPlanRepository
{
    Task<IEnumerable<Plan>> GetAll();
    Task<Plan> GetByGuid(Guid planGuid);
    Task<Plan> GetById(long planId);
}