// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Motoca.Core.Domain.Utils;
using Motoca.Core.Infrastructure.Queue.Connections;
using RabbitMQ.Client;

DotEnvUtils.Load();

var scope = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        var connection = CoreQueueConnectionFactory.GetConnection(EnvironmentUtils.TryGetEnvironmentVariable("RABBITMQ_CORE"));
        
        services.AddKeyedTransient<IConnection>("rabbit_core", (_, _) => connection);
        services.AddLogging();
    })
    .Build()
    .Services
    .CreateScope()
    .ServiceProvider;

var logger = scope.GetRequiredService<ILogger<Program>>();
using var connection = scope.GetRequiredKeyedService<IConnection>("rabbit_core");
using var channel = connection.CreateModel();

try
{
    logger.LogInformation("[QueueInitializer] Inicializando filas");
    
    QueueUtils.Create(channel, "motorcycle_registered", "motorcycle", "direct");
    
    logger.LogInformation("[QueueInitializer] Filas inicializadas com sucesso");
}
catch (Exception e)
{
    logger.LogTrace(e, e.Message);
}



