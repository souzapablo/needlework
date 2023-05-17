using NeedleWork.Core.Enums;

namespace NeedleWork.Core.Entities;

public class User : BaseEntity
{
    public User(string username, string userTag, string email, string password)
    {
        Username = username;
        UserTag = userTag;
        Email = email;
        Password = password;
        Customers = new List<Customer>();
        Orders = new List<Order>();
        Purchases = new List<Purchase>();
    }

    public string Username { get; private set; }
    public string UserTag { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public Role Role { get; private set; }
    public List<Customer> Customers { get; private set; }
    public List<Order> Orders { get; private set; }
    public List<Purchase> Purchases { get; private set; }
}