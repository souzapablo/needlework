namespace NeedleWork.Core.Entities;

public class Product : BaseEntity
{
    public Product(long supplierId, string description, decimal price)
    {
        SupplierId = supplierId;
        Description = description;
        Price = price;
    }

    public long SupplierId { get; private set; }
    public Supplier Supplier { get; private set; } = null!;
    public string Description { get; private set; }
    public decimal Price { get; private set; }

    public void UpdateDescription(string description) =>
        Description = description;

    public void UpdatePrice(decimal price) =>
        Price = price;
}