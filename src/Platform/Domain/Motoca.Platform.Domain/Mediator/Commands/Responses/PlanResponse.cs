namespace Motoca.Platform.Domain.Mediator.Commands.Responses;

public class PlanResponse
{
    public Guid Guid { get; set; }
    public int TotalDays { get; set; }
    public decimal CostPerDay { get; set; }
}