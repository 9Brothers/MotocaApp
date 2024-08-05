using MediatR;
using Microsoft.Extensions.Logging;

namespace Motoca.Platform.Domain.Mediator.NotificationHandlers;

public class DeliverymanNotificationHandler(ILogger<DeliverymanNotificationHandler> logger)
    : INotificationHandler<CreatedDeliverymanNotification>
{
    private readonly ILogger<DeliverymanNotificationHandler> _logger = logger;

    public Task Handle(CreatedDeliverymanNotification notification, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            logger.LogInformation($"Motoca cadastrado com sucesso. | CNPJ: {notification.CNPJ} | Nome: {notification.Name}");
        });
    }
}