using NeedleWork.Core.Enums;

namespace NeedleWork.Core.Entities;

public class Order : BaseEntity
{
    public Order(long userId, long customerId, PaymentMethod paymentMethod, decimal shipment)
    {
        UserId = userId;
        CustomerId = customerId;
        PaymentMethod = paymentMethod;
        Shipment = shipment;
        Embroideries = new List<Embroidery>();
        Payments = new List<Payment>();
    }

    public long UserId { get; private set; }
    public User User { get; private set; } = null!;
    public long CustomerId { get; private set; }
    public Customer Customer { get; private set; } = null!;
    public List<Embroidery> Embroideries { get; private set; }
    public PaymentMethod PaymentMethod { get; private set; }
    public decimal Shipment { get; private set; }
    public decimal TotalPrice { get; private set; }
    public List<Payment> Payments { get; private set; }
}