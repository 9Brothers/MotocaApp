using MediatR;
using Microsoft.EntityFrameworkCore;
using Motoca.Core.Domain.Entities;
using Motoca.Core.Domain.Interfaces.Repositories;
using Motoca.Core.Domain.Mediator.Commands.Requests;
using Motoca.Core.Domain.Mediator.Notifications;

namespace Motoca.Core.Domain.Mediator.EventHandlers;

public class CreateAdministratorCommandHandler(
    IMediator mediator,
    IAdministratorRepository repository,
    ICoreWriteUnitOfWork writeUnitOfWork
    ) : IRequestHandler<CreateAdministratorCommand, Unit>
{
    private readonly DbContext context = writeUnitOfWork.GetContext();
    
    public async Task<Unit> Handle(CreateAdministratorCommand request, CancellationToken cancellationToken)
    {
        var administrator = request.ToAdministrator();
        
        administrator.Validate();

        var exists = await repository.Exists(administrator.Email);
        
        if (exists)
            throw new Exception("Este E-mail já está cadastrado.");

        context.Set<Administrator>().Add(administrator);
        context.SaveChanges();

        await mediator.Publish(new CreatedAdministratorNotification
        {
            Name = administrator.Name,
            Email = administrator.Email
        });
        
        return Unit.Value;
    }
}