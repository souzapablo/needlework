using NeedleWork.Core.Enums;

namespace NeedleWork.Application.ViewModels.Users;

public record UserViewModel(
    long Id,
    string Name,
    UserRole Role
);