namespace NeedleWork.Core.Entities;

public class PurchaseItem : BaseEntity
{
    public PurchaseItem(long purchaseId, long productId, int quantity, decimal? discount)
    {
        PurchaseId = purchaseId;
        ProductId = productId;
        Quantity = quantity;
        Discount = discount;
    }

    public long PurchaseId { get; private set; }
    public Purchase Purchase { get; private set; } = null!;
    public long ProductId { get; private set; }
    public Product Product { get; private set; } = null!;
    public int Quantity { get; private set; }
    public decimal? Discount { get; private set; }
}