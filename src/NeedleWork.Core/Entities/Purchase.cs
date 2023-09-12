using NeedleWork.Core.Entities.Shared;

namespace NeedleWork.Core.Entities;
public class Purchase : BaseEntity
{
    public Purchase() { }

    public Purchase(long userId, DateTime purchaseDate)
    {
        UserId = userId;
        PurchaseDate = purchaseDate;
        Items = new();
    }

    public long UserId { get; private set; }
    public User User { get; private set; } = null!;
    public List<PurchaseItem> Items { get; private set; } = new();
    public DateTime PurchaseDate { get; private set; }
    public decimal Total { get; private set; }

    public void AddItem(PurchaseItem item)
    {
        Items.Add(item);
        CalculateTotal();
    }

    public void CalculateTotal()
    {
        decimal total = 0;

        foreach (var item in Items)
        {
            total += item.Quantity * item.Product.Price;
        }

        Total = total;
    }
}
