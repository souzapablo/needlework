namespace NeedleWork.Core.Entities;

public class Payment : BaseEntity
{
    public Payment(long orderId, DateTime dueDate, bool hasPayed)
    {
        OrderId = orderId;
        DueDate = dueDate;
    }
    
    public long OrderId { get; private set; }
    public Order Order { get; private set; } = null!;
    public DateTime DueDate { get; private set; }
    public bool HasPayed { get; private set; }

}