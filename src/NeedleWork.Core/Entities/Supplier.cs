namespace NeedleWork.Core.Entities;

public class Supplier : BaseEntity
{
    public Supplier(string name, string contact)
    {
        Name = name;
        Contact = contact;
        Products = new List<Product>();
    }

    public string Name { get; private set; }
    public string Contact { get; private set; }
    public List<Product> Products { get; private set; }
}