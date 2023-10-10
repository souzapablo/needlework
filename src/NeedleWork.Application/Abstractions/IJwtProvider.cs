using NeedleWork.Application.Models.Users;
using NeedleWork.Core.Entities;

namespace NeedleWork.Application.Abstractions;

public interface IJwtProvider
{
    string Generate(UserLoginDTO user);
}