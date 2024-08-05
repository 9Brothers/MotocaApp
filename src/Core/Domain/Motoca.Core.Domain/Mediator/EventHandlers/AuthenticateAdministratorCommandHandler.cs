using System.Security.Claims;
using MediatR;
using Motoca.Core.Domain.Interfaces.Repositories;
using Motoca.Core.Domain.Mediator.Commands.Requests;
using Motoca.Core.Domain.Mediator.Commands.Responses;
using Motoca.Core.Domain.Utils;

namespace Motoca.Core.Domain.Mediator.EventHandlers;

public class AuthenticateAdministratorCommandHandler(
    IAdministratorRepository administratorRepository)
    : IRequestHandler<AuthenticateAdministratorCommand, AuthenticationResponse>
{
    public async Task<AuthenticationResponse> Handle(AuthenticateAdministratorCommand request, CancellationToken cancellationToken)
    {
        var administrator = await administratorRepository.FindByEmail(request.Email);

        if (administrator is null)
            throw new Exception("E-mail não encontrado.");
        
        var claims = new List<Claim>();            
        claims.Add(new Claim("AdministratorId", administrator!.Id.ToString()));
        claims.Add(new Claim("Administrator", ""));

        var token = AuthUtils.GenerateToken(claims);

        return new AuthenticationResponse
        {
            Token = token
        };
    }
}