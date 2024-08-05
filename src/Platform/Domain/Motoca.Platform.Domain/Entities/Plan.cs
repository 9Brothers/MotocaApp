using Motoca.Core.Domain.Entities;

namespace Motoca.Platform.Domain.Entities;

public class Plan : Entity
{
    public Plan()
    {
        Rentals = new List<Rental>();
    }
    
    public int TotalDays { get; set; }
    public decimal CostPerDay { get; set; }
    public decimal Fee { get; set; }

    public IEnumerable<Rental> Rentals { get; set; }
}