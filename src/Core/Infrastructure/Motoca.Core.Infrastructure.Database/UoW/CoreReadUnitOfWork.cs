using Motoca.Core.Domain.Interfaces.Repositories;
using Motoca.Core.Infrastructure.Database.Contexts;

namespace Motoca.Core.Infrastructure.Database.UoW;

public class CoreReadUnitOfWork : UnitOfWork<CoreReadContext>, ICoreReadUnitOfWork
{
    public CoreReadUnitOfWork(CoreReadContext dbReadContext, IServiceProvider serviceProvider) : base(dbReadContext, serviceProvider)
    {
    }
}