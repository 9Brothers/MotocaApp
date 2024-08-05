using MediatR;

namespace Motoca.Platform.Domain.Mediator.Notifications;

public class RegisteredMotorcycleNotification : INotification
{
    public Guid Guid { get; set; }
    public short Year { get; set; }
    public string Model { get; set; }
    public string LicensePlate { get; set; }
}