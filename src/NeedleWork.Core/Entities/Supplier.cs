using NeedleWork.Core.Entities.Shared;

namespace NeedleWork.Core.Entities;

public class Supplier : BaseEntity
{
    public string Name { get; private set; }
    public string Contact { get; private set; }
    public List<Product> Products { get; private set; } = new List<Product>();

    public Supplier(string name, string contact)
    {
        Name = name;
        Contact = contact;
    }

    public void UpdateContact(string newContact)
    {
        Contact = newContact;
    }
}