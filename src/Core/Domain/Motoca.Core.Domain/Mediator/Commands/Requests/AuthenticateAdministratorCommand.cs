using MediatR;
using Motoca.Core.Domain.Mediator.Commands.Responses;

namespace Motoca.Core.Domain.Mediator.Commands.Requests;

public class AuthenticateAdministratorCommand : IRequest<AuthenticationResponse>
{
    public string Email { get; set; }
}