using NeedleWork.Core.Enums;

namespace NeedleWork.Core.Entities;

public class User : BaseEntity
{
    public User(string email, string password)
    {
        Email = email;
        Password = password;
        Customers = new List<Customer>();
        Orders = new List<Order>();
        Purchases = new List<Purchase>();
    }

    public string Email { get; private set; }
    public string Password { get; private set; }
    public Role Role { get; private set; }
    public List<Customer> Customers { get; private set; }
    public List<Order> Orders { get; private set; }
    public List<Purchase> Purchases { get; private set; }
}