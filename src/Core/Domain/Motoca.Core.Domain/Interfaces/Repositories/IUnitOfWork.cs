using Microsoft.EntityFrameworkCore;
using Motoca.Core.Domain.Entities;

namespace Motoca.Core.Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
    IRepository<TEntity> Repository<TEntity>() where TEntity : Entity;
    DbContext GetContext();
}