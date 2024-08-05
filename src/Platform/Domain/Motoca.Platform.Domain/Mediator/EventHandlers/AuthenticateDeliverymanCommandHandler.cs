using System.Security.Claims;
using MediatR;
using Motoca.Core.Domain.Mediator.Commands.Responses;
using Motoca.Core.Domain.Utils;
using Motoca.Platform.Domain.Interfaces.Repositories;
using Motoca.Platform.Domain.Mediator.Commands.Requests;

namespace Motoca.Platform.Domain.Mediator.EventHandlers;

public class AuthenticateDeliverymanCommandHandler(
    IDeliverymanRepository deliverymanRepository)
    : IRequestHandler<AuthenticateDeliverymanCommand, AuthenticationResponse>
{
    public async Task<AuthenticationResponse> Handle(AuthenticateDeliverymanCommand request, CancellationToken cancellationToken)
    {
        var deliveryman = await deliverymanRepository.FindByCNPJ(request.CNPJ);

        if (deliveryman is null)
            throw new Exception("CNPJ não encontrado.");
        
        var claims = new List<Claim>();            
        claims.Add(new Claim("DeliverymanId", deliveryman!.Id.ToString()));
        claims.Add(new Claim("Deliveryman", ""));

        var token = AuthUtils.GenerateToken(claims);

        return new AuthenticationResponse
        {
            Token = token
        };
    }
}