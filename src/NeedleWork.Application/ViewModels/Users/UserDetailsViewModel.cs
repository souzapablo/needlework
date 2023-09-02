using NeedleWork.Core.Enums;

namespace NeedleWork.Application.ViewModels.Users;

public record UserDetailsViewModel(
    long id,
    string Name,
    UserRole Role,
    string Email,
    DateOnly BirthDate
);