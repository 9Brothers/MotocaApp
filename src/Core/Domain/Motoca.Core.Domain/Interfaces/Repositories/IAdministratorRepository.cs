using Motoca.Core.Domain.Entities;

namespace Motoca.Core.Domain.Interfaces.Repositories;

public interface IAdministratorRepository
{
    Task<bool> Exists(string email);
    Task<Administrator> FindByEmail(string email);
}