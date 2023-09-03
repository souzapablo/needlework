using NeedleWork.Core.Entities;

namespace NeedleWork.Application.Abstractions;

public interface IJwtProvider
{
    string Generate(User user);
}