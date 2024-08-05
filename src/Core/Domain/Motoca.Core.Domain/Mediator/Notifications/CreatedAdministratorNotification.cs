using MediatR;

namespace Motoca.Core.Domain.Mediator.Notifications;

public class CreatedAdministratorNotification : INotification
{
    public string Name { get; set; }
    public string Email { get; set; }
}