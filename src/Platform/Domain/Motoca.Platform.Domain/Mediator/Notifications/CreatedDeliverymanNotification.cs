using MediatR;

namespace Motoca.Platform.Domain.Mediator.NotificationHandlers;

public class CreatedDeliverymanNotification : INotification
{
    public string CNPJ { get; set; }
    public string Name { get; set; }
}