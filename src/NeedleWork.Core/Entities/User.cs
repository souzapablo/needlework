using NeedleWork.Core.Entities.Shared;
using NeedleWork.Core.Enums;

namespace NeedleWork.Core.Entities;

public class User : BaseEntity
{
    public User() { }

    public User(string firstName, string lastName, string email, string password, DateOnly birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        BirthDate = birthDate;

        Addresses = new();
    }

    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public DateOnly BirthDate { get; private set; }
    public UserRole Role { get; private set; } = UserRole.User;
    public List<Address> Addresses { get; private set; } = new();

    public string FullName => $"{FirstName} {LastName}";

    public void AddAddress(Address address) 
    {
        Addresses.Add(address);
    }
}