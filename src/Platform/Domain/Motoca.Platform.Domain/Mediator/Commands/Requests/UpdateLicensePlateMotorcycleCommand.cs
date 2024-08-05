using MediatR;

namespace Motoca.Platform.Domain.Mediator.Commands.Requests;

public class UpdateLicensePlateMotorcycleCommand : IRequest<Unit>
{
    public string WrongLicensePlate { get; set; }
    public string CorrectLicensePlate { get; set; }
    public long? AdministratorId { get; set; }
}