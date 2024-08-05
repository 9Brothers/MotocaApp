using Motoca.Platform.Domain.Entities;

namespace Motoca.Platform.Domain.Interfaces.Repositories;

public interface IRentalRepository
{
    Task<bool> ExistsOpenByDeliverymanId(long? deliverymanId);
    Task<Rental> OpenByDeliverymanId(long deliverymanId);
    Task<bool> ExistsByMotorcycleId(long motorcycleId);
}