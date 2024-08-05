using System.Text;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Motoca.Core.Domain.Utils;
using Motoca.Core.Infrastructure.Queue.Connections;
using Motoca.Platform.Domain.Entities;
using Motoca.Platform.Domain.Interfaces.Repositories;
using Motoca.Platform.Domain.Mediator.Notifications;
using Motoca.Platform.Infrastructure.Database.Contexts;
using Motoca.Platform.Infrastructure.Database.Repositories;
using Motoca.Platform.Infrastructure.Database.UoW;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

DotEnvUtils.Load();

var scope = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        var connection = CoreQueueConnectionFactory.GetConnection(EnvironmentUtils.TryGetEnvironmentVariable("RABBITMQ_CORE"));
        
        services.AddKeyedTransient<IConnection>("rabbit_core", (_, _) => connection);
        services.AddDbContext<PlatformWriteContext>();
        services.AddScoped<IPlatformReaderConnection, PlatformReaderConnection>();
        services.AddScoped<IPlatformWriteUnitOfWork, PlatformWriteUnitOfWork>();
        services.AddScoped<IPlatformEventRepository, PlatformEventRepository>();
        
        services.AddLogging();
    })
    .Build()
    .Services
    .CreateScope()
    .ServiceProvider;

var logger = scope.GetRequiredService<ILogger<Program>>();
var eventRepository = scope.GetRequiredService<IPlatformEventRepository>();
var context = scope.GetRequiredService<IPlatformWriteUnitOfWork>().GetContext();
using var connection = scope.GetRequiredKeyedService<IConnection>("rabbit_core");
using var channel = connection.CreateModel();

var consumer = new EventingBasicConsumer(channel);
consumer.Received += async (ch, ea) =>
{
    try
    {
        var body = ea.Body.ToArray();
        var json = Encoding.UTF8.GetString(body);
        var motorcycle = JsonSerializer.Deserialize<RegisteredMotorcycleNotification>(json);

        var lastSequence = await eventRepository.LastSequence(motorcycle.Guid);

        PlatformEvent platformEvent = new()
        {
            Log = json,
            Sequence = ++lastSequence
        };

        context.Set<PlatformEvent>().Add(platformEvent);
        context.SaveChanges();
        
        var message = string.Format("Motoca cadastrada | Placa: {0} | Modelo: {1} | Ano: {2} | Guid: {3}",
            motorcycle.LicensePlate, motorcycle.Model, motorcycle.Year, motorcycle.Guid);
            
        if (motorcycle?.Year == 2024)
            message = string.Format("Aí sim, uma motoca novinha foi cadastrada | Placa: {0} | Modelo: {1} | Ano: {2} | Guid: {3}",
                motorcycle.LicensePlate, motorcycle.Model, motorcycle.Year, motorcycle.Guid);
        
        logger.LogInformation(message);
    }
    catch (Exception e)
    {
        channel.BasicReject(ea.DeliveryTag, true);
                
        logger.LogError(e, e.Message);
    }
};

channel.BasicConsume(
    "motorcycle_registered",
    true,
    consumer);

logger.LogInformation("[MotocaConsumer] Inicializado");
    
await Task.Delay(-1);