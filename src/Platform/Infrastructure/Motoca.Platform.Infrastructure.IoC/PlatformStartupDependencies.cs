using Microsoft.Extensions.DependencyInjection;
using Motoca.Core.Domain.Utils;
using Motoca.Core.Infrastructure.Queue.Connections;
using Motoca.Platform.Domain.Interfaces.Repositories;
using Motoca.Platform.Infrastructure.Database.Contexts;
using Motoca.Platform.Infrastructure.Database.Repositories;
using Motoca.Platform.Infrastructure.Database.UoW;
using RabbitMQ.Client;

namespace Motoca.Platform.Infrastructure.IoC;

public static class PlatformStartupDependencies
{
    public static void AddDependencyInjection(this IServiceCollection services)
    {
        AddRepositories(services);
    }
   
    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddDbContext<PlatformWriteContext>();
        services.AddScoped<IPlatformWriteUnitOfWork, PlatformWriteUnitOfWork>();
        services.AddScoped<IPlatformReaderConnection, PlatformReaderConnection>();
        services.AddScoped<IDeliverymanRepository, DeliverymanRepository>();
        services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
        services.AddScoped<IPlanRepository, PlanRepository>();
        services.AddScoped<IRentalRepository, RentalRepository>();

        var connection = CoreQueueConnectionFactory.GetConnection(EnvironmentUtils.TryGetEnvironmentVariable("RABBITMQ_CORE"));
        
        services.AddKeyedSingleton<IConnection>("rabbit_core", (_, _) => connection);
    }

    public static void AddMediatRHandlers(this IServiceCollection services)
    {
        services.AddMediatR(p => p.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
    }
}
