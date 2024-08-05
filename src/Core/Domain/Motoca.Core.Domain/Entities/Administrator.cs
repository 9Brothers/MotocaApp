using FluentValidation;
using Motoca.Core.Domain.Interfaces;
using Motoca.Core.Domain.Validator;

namespace Motoca.Core.Domain.Entities;

public class Administrator : User, IValidable
{
    private readonly AdministratorValidator _validator;

    public Administrator()
    {
        _validator = new AdministratorValidator();
    }
    
    public void Validate()
    {
        _validator.ValidateAndThrow(this);
    }
}