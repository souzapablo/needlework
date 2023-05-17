using NeedleWork.Core.Enums;

namespace NeedleWork.Application.ViewModels.Users;

public record UserDetailsViewModel(
    long Id,
    string Username,
    string UserTag,
    string Email,
    Role Role,
    int Customers,
    int Orders,
    int Purchases);
