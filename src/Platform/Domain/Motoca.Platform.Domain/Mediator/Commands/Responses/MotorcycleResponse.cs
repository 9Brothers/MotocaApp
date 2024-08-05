namespace Motoca.Platform.Domain.Mediator.Commands.Responses;

public class MotorcycleResponse
{
    public Guid Guid { get; set; }
    public short Year { get; set; }
    public string Model { get; set; }
    public string LicensePlate { get; set; }
}