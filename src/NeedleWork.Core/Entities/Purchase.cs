using NeedleWork.Core.Entities.Shared;
using NeedleWork.Core.Exceptions;
using NeedleWork.Core.Shared;

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
        VerifyIfExists(item.Product);
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

    private void VerifyIfExists(Product product)
    {
        foreach (PurchaseItem item in Items)
        {
            if (item.Product == product)
                throw new PurchaseItemAlreadyPresentException(Errors.PurchaseItemAlreadyPresent(product.Description));
        }
    }
}
