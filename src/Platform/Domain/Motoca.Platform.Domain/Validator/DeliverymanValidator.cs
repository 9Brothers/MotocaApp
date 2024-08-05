using FluentValidation;
using Motoca.Platform.Domain.Entities;

namespace Motoca.Platform.Domain.Validator;

public class DeliverymanValidator : AbstractValidator<Deliveryman>
{
    public DeliverymanValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Email).NotEmpty().EmailAddress();
        RuleFor(p => p.CNPJ).Length(14);
        RuleFor(p => p.Birthdate).NotEmpty();
        RuleFor(p => p.CNH).NotEmpty();
        RuleFor(p => p.CnhType).NotEmpty().Matches("^A|B$");
    }
}