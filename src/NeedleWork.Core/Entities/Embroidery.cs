namespace NeedleWork.Core.Entities;

public class Embroidery : BaseEntity
{
    public Embroidery(long userId, long orderId, string description, decimal price)
    {
        OrderId = orderId;
        Description = description;
        Price = price;
    }

    public long OrderId { get; private set; }
    public Order Order { get; private set; } = null!;
    public string Description { get; private set; }
    public decimal Price { get; private set; }
}