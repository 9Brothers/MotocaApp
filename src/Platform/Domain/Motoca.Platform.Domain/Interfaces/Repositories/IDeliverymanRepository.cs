using Motoca.Platform.Domain.Entities;

namespace Motoca.Platform.Domain.Interfaces.Repositories;

public interface IDeliverymanRepository
{
    Task<bool> ExistsCNPJ(string cnpj);
    Task<Deliveryman> FindByCNPJ(string email);
    Task<Deliveryman> FindById(long deliverymanId);
}