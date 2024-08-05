using Motoca.Platform.Domain.Entities;
using Motoca.Platform.Domain.Mediator.Commands.Responses;

namespace Motoca.Platform.Domain.Interfaces.Repositories;

public interface IMotorcycleRepository
{
    Task<bool> Exists(string licensePlate);
    Task<IEnumerable<MotorcycleResponse>> GetAllByLicensePlate(string licensePlate, int page = 0);
    Task<Motorcycle> GetByLicensePlate(string licensePlate);
    Task<Motorcycle> FirstAvailable();
    Task<Motorcycle> GetById(long motorcycleId);
    Task<Motorcycle> GetByGuid(Guid motorcycleGuid);
}