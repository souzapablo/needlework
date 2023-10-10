using NeedleWork.Core.Enums;

namespace NeedleWork.Application.Models.Users;
public record UserLoginDTO(
    long Id,
    string Email,
    UserRole Role);