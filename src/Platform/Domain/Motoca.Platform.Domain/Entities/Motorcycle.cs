using FluentValidation;
using Motoca.Core.Domain.Entities;
using Motoca.Core.Domain.Interfaces;
using Motoca.Platform.Domain.Validator;

namespace Motoca.Platform.Domain.Entities;

public class Motorcycle : Entity, IValidable
{
    private readonly MotorcycleValidator _validator;

    public Motorcycle()
    {
        _validator = new MotorcycleValidator();
    }
    
    public short Year { get; set; }
    public string Model { get; set; }
    public string LicensePlate { get; set; }
    public bool Available { get; set; } = true;
    
    public void Validate()
    {
        _validator.ValidateAndThrow(this);
    }
}