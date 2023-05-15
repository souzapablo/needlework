namespace NeedleWork.Core.Entities;

public class Customer : BaseEntity
{
    public Customer(long userId, string name, string contact)
    {
        UserId = userId;
        Name = name;
        Contact = contact;
        Orders = new List<Order>();
    }

    public long UserId { get; private set; }
    public User User { get; private set; } = null!;
    public string Name { get; private set; }
    public string Contact { get; private set; }
    public List<Order> Orders { get; private set; }
}