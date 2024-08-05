using MediatR;
using Motoca.Core.Domain.Mediator.Commands.Responses;

namespace Motoca.Platform.Domain.Mediator.Commands.Requests;

public class AuthenticateDeliverymanCommand : IRequest<AuthenticationResponse>
{
    public string CNPJ { get; set; }
}