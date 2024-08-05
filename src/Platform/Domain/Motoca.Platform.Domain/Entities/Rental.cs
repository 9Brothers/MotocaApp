using Motoca.Core.Domain.Entities;

namespace Motoca.Platform.Domain.Entities;

public class Rental : Entity
{
    public DateTime Start { get; set; }
    public DateTime ExpectedEnd { get; set; }
    public DateTime? End { get; set; }
    public decimal Fee { get; set; }

    public long DeliverymanId { get; set; }
    public Deliveryman Deliveryman { get; set; }

    public long MotorcycleId { get; set; }
    public Motorcycle Motorcycle { get; set; }

    public long PlanId { get; set; }
    public Plan Plan { get; set; }
    
}