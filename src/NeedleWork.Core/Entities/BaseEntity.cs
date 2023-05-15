namespace NeedleWork.Core.Entities;

public class BaseEntity
{
    public long Id { get; }
    public DateTime CreatedAt { get; } = DateTime.Now;
    public bool IsDeleted { get; private set; }

    public void Delete() => IsDeleted = true;
}