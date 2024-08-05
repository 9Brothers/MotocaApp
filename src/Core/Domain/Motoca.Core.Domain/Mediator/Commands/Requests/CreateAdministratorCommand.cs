using MediatR;
using Motoca.Core.Domain.Entities;

namespace Motoca.Core.Domain.Mediator.Commands.Requests;

public class CreateAdministratorCommand : IRequest<Unit>
{
    public string Name { get; set; }
    public string Email { get; set; }
    
    public Administrator ToAdministrator()
    {
        return new()
        {
            Name = Name.Trim(),
            Email = Email.Trim()
        };
    }
}