using NeedleWork.Core.Entities.Shared;

namespace NeedleWork.Core.Entities;

public class Supplier : BaseEntity
{
    public Supplier() { }

    public Supplier(string name, string contact)
    {
        Name = name;
        Contact = contact;
    }

    public string Name { get; private set; } = string.Empty;
    public string Contact { get; private set; } = string.Empty;
    public List<Product> Products { get; private set; } = new List<Product>();

    public void UpdateContact(string newContact)
    {
        Contact = newContact;
    }
}