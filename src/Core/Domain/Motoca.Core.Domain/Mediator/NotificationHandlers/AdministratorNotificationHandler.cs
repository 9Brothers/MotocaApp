using MediatR;
using Microsoft.Extensions.Logging;
using Motoca.Core.Domain.Mediator.Notifications;

namespace Motoca.Core.Domain.Mediator.NotificationHandlers;

public class AdministratorNotificationHandler(
    ILogger<AdministratorNotificationHandler> logger
    ) : INotificationHandler<CreatedAdministratorNotification>
{
    public Task Handle(CreatedAdministratorNotification notification, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            logger.LogInformation("Admin cadastrado com sucesso. | Email: {NotificationEmail} | Nome: {NotificationName}", notification.Email, notification.Name);
        });
    }
}