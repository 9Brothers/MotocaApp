using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Motoca.Core.Domain.Entities;
using Motoca.Core.Domain.Interfaces.Repositories;

namespace Motoca.Core.Infrastructure.Database.UoW;

public class UnitOfWork<Context> : IUnitOfWork where Context : DbContext
{
    private readonly Context _dbReadContext;
    private readonly IServiceProvider _serviceProvider;
    private int _transactions;
    private Dictionary<string, dynamic> _repositories;
        
    public UnitOfWork(Context dbReadContext, IServiceProvider serviceProvider)
    {
        _dbReadContext = dbReadContext;
        _serviceProvider = serviceProvider;
        _transactions = 0;
    }

    public async Task BeginTransaction()
    {
        if (_transactions == 0)
            await _dbReadContext.Database.BeginTransactionAsync();

        _transactions++;
    }

    public async Task Commit()
    {
        if (_transactions == 1)
            await _dbReadContext.Database.CommitTransactionAsync();

        _transactions--;
    }

    public IRepository<TEntity> Repository<TEntity>() where TEntity : Entity
    {
        if (_repositories == null)
            _repositories = new Dictionary<string, dynamic>();

        var type = typeof(TEntity).Name;

        if (_repositories.ContainsKey(type))
            return (IRepository<TEntity>)_repositories[type];

        var instance = _serviceProvider.GetRequiredService<IRepository<TEntity>>();

        _repositories.Add(type, instance);

        return _repositories[type];
    }

    public DbContext GetContext()
    {
        return _dbReadContext;
    }

    public async Task Rollback()
    {
        if (_dbReadContext.Database.CurrentTransaction is not null)
            await _dbReadContext.Database.RollbackTransactionAsync();

        _transactions = 0;
    }
}