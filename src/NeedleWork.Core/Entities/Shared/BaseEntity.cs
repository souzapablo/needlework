namespace NeedleWork.Core.Entities.Shared;

public abstract class BaseEntity
{
    public long Id { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime LastUpdate { get; private set; } = DateTime.UtcNow;
    public bool IsActive { get; private set; } = true;
}