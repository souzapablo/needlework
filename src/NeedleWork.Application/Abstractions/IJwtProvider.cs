using NeedleWork.Application.Models.Users;

namespace NeedleWork.Application.Abstractions;

public interface IJwtProvider
{
    string Generate(UserLoginDTO user);
}