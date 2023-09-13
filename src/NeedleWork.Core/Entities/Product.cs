using NeedleWork.Core.Entities.Shared;
using NeedleWork.Core.Enums;

namespace NeedleWork.Core.Entities;

public class Product : BaseEntity
{
    public long SupplierId { get; private set; }
    public Supplier Supplier { get; private set; } = null!;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public UnitOfMeasurement UnitOfMeasurement { get; private set; }

    public Product() { }
    public Product(long supplierId, string description, decimal price, UnitOfMeasurement unitOfMeasurement)
    {
        SupplierId = supplierId;
        Description = description;
        Price = price;
        UnitOfMeasurement = unitOfMeasurement;   
    }
}