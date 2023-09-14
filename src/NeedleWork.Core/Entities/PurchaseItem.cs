using NeedleWork.Core.Entities.Shared;

namespace NeedleWork.Core.Entities;
public class PurchaseItem : BaseEntity
{
    public PurchaseItem() { }
    public PurchaseItem(Product product, decimal quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    public long ProductId { get; private set; }
    public Product Product { get; private set; } = null!;
    public decimal Quantity { get; private set; }
}
