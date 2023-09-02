namespace NeedleWork.Application.ViewModels.Users;

public record UserDetailsViewModel(
    long id,
    string Name,
    string Email,
    DateOnly BirthDate
);