using FluentValidation;
using Motoca.Core.Domain.Entities;
using Motoca.Core.Domain.Interfaces;
using Motoca.Platform.Domain.Validator;

namespace Motoca.Platform.Domain.Entities;

public class Deliveryman : User, IValidable
{
    private readonly DeliverymanValidator _validator;

    public Deliveryman()
    {
        _validator = new DeliverymanValidator();
        Rentals = new List<Rental>();
    }
    
    public DateTime Birthdate { get; set; }
    public string CNPJ { get; set; }
    public string CNH { get; set; }
    public string CnhType { get; set; }
    public string? CnhUrl { get; set; }
    
    public IEnumerable<Rental> Rentals { get; set; }

    public void Validate()
    {
        _validator.ValidateAndThrow(this);
    }
}