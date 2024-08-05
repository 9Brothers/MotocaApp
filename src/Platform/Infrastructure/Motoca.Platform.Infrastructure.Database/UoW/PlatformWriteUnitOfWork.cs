using Motoca.Core.Infrastructure.Database.UoW;
using Motoca.Platform.Domain.Interfaces.Repositories;
using Motoca.Platform.Infrastructure.Database.Contexts;

namespace Motoca.Platform.Infrastructure.Database.UoW;

public class PlatformWriteUnitOfWork(PlatformWriteContext dbWriteContext, IServiceProvider serviceProvider)
    : UnitOfWork<PlatformWriteContext>(dbWriteContext, serviceProvider), IPlatformWriteUnitOfWork;