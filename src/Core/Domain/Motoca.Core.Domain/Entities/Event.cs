namespace Motoca.Core.Domain.Entities;

public class Event : Entity
{
    public string Log { get; set; }
    public uint Sequence { get; set; }
}