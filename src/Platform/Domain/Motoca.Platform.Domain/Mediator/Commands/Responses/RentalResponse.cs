namespace Motoca.Platform.Domain.Mediator.Commands.Responses;

public class RentalResponse
{
    public Guid MotorcycleGuid { get; set; }
    public short Year { get; set; }
    public string Model { get; set; }
    public string LicensePlate { get; set; }
    public Guid RentalGuid { get; set; }
}