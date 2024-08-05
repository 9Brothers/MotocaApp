using MediatR;
using Motoca.Platform.Domain.Entities;

namespace Motoca.Platform.Domain.Mediator.Commands.Requests;

public class RegisterMotorcycleCommand : IRequest<Unit>
{
    public short Year { get; set; }
    public string Model { get; set; }
    public string LicensePlate { get; set; }
    public long? AdministratorId { get; set; }

    public Motorcycle ToMotorcycle()
    {
        return new()
        {
            Year = Year,
            Model = Model.Trim(),
            LicensePlate = LicensePlate.Trim(),
            CreatedBy = AdministratorId.Value,
            UpdatedBy = AdministratorId.Value
        };
    }
}