using System.Text;
using System.Text.Json;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Motoca.Platform.Domain.Mediator.Notifications;
using RabbitMQ.Client;

namespace Motoca.Platform.Domain.Mediator.NotificationHandlers;

public class MotorcycleNotificationHandler(
    ILogger<MotorcycleNotificationHandler> logger,
    [FromKeyedServices("rabbit_core")] IConnection rabbitConnection
    ) : INotificationHandler<RegisteredMotorcycleNotification>
{
    public Task Handle(RegisteredMotorcycleNotification notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Motoca cadastrada. | Placa: {LicensePlate} | Modelo: {Model} | Ano: {Year}", notification.LicensePlate, notification.Model, notification.Year);

        var json = JsonSerializer.Serialize(notification);
        var buffer = Encoding.UTF8.GetBytes(json);
        
        using var channel = rabbitConnection.CreateModel();
        
        channel.BasicPublish(
            exchange: "motorcycle",
            routingKey: "motorcycle_registered",
            body: buffer);

        return Task.CompletedTask;
    }
}