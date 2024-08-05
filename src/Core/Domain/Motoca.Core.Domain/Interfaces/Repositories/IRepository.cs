using Microsoft.EntityFrameworkCore;
using Motoca.Core.Domain.Entities;

namespace Motoca.Core.Domain.Interfaces.Repositories;

public interface IRepository<TEntity> where TEntity : Entity
{
    DbSet<TEntity> Queryable();
}