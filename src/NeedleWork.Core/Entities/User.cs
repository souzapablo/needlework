using NeedleWork.Core.Entities.Shared;
using NeedleWork.Core.Enums;

namespace NeedleWork.Core.Entities;

public class User : BaseEntity
{
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public DateOnly BirthDate { get; private set; }
    public UserRole Role { get; private set; } = UserRole.User;

    public User() { }

    public User(string firstName, string lastName, string email, string password, DateOnly birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        BirthDate = birthDate;
    }

    public string FullName => $"{FirstName} {LastName}";
}