using System.Text.RegularExpressions;
using MediatR;
using Motoca.Platform.Domain.Entities;

namespace Motoca.Platform.Domain.Mediator.Commands.Requests;

public class CreateDeliverymanCommand : IRequest<Unit>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string CNPJ { get; set; }
    public string CNH { get; set; }
    public string CnhType { get; set; }
    public DateTime Birthdate { get; set; }
    
    public Deliveryman ToDeliveryman()
    {
        var regex = new Regex("\\D");
        
        return new Deliveryman
        {
            Name = Name.Trim(),
            Email = Email.Trim(),
            Birthdate = Birthdate,
            CNPJ = regex.Replace(CNPJ, ""),
            CNH = regex.Replace(CNH, ""),
            CnhType = CnhType
        };
    }
}