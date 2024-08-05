using FluentValidation;
using Motoca.Core.Domain.Entities;

namespace Motoca.Core.Domain.Validator;

public class AdministratorValidator : AbstractValidator<Administrator>
{
    public AdministratorValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Email).NotEmpty().EmailAddress();
    }
}