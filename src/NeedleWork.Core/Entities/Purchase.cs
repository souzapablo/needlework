namespace NeedleWork.Core.Entities;

public class Purchase : BaseEntity
{
    public Purchase(long userId)
    {
        UserId = userId;
        Items = new List<PurchaseItem>();
    }

    public long UserId { get; private set; }
    public User User { get; private set; } = null!;
    public List<PurchaseItem> Items { get; private set; }
    public decimal TotalPrice { get; private set; }
}