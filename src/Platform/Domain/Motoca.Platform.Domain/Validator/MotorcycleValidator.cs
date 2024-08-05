using FluentValidation;
using Motoca.Platform.Domain.Entities;

namespace Motoca.Platform.Domain.Validator;

public class MotorcycleValidator : AbstractValidator<Motorcycle>
{
    public MotorcycleValidator()
    {
        RuleFor(p => p.Year).GreaterThan((short)2010);
        RuleFor(p => p.Model).NotEmpty();
        RuleFor(p => p.LicensePlate)
            .NotEmpty()
            .MaximumLength(7)
            .Matches("[A-Z]{3}[0-9]([A-Z]{1}|[0-9]{1})[0-9]{2}");
    }
}