namespace Motoca.Core.Domain.Entities;

public class Entity
{
    public Entity()
    {
        Guid = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }
    
    public long Id { get; set; }
    public Guid Guid { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool Enabled { get; set; } = true;
    public long CreatedBy { get; set; }
    public long UpdatedBy { get; set; }
}