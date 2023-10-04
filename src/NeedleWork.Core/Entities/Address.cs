using NeedleWork.Core.Entities.Shared;

namespace NeedleWork.Core.Entities;

public class Address : BaseEntity
{
    public long UserId { get; private set; }
    public User User { get; private set; } = null!;
    public string Cep { get; set; } =  string.Empty;
    public string State { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Neighborhood { get; set; } = string.Empty;
    public int Number { get; set; } 
    public string? Complement { get; set; }

    public Address() { }
    public Address(string cep)
    {
        Cep = cep;
    }
}