using Motoca.Core.Domain.Interfaces.Repositories;
using Motoca.Core.Infrastructure.Database.Contexts;

namespace Motoca.Core.Infrastructure.Database.UoW;

public class CoreWriteUnitOfWork : UnitOfWork<CoreWriteContext>, ICoreWriteUnitOfWork
{
    public CoreWriteUnitOfWork(CoreWriteContext dbWriteContext, IServiceProvider serviceProvider) : base(dbWriteContext, serviceProvider)
    {
    }
}