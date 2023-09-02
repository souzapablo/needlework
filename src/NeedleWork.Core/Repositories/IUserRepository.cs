using NeedleWork.Core.Entities;

namespace NeedleWork.Core.Repositories;

public interface IUserRepository
{
    Task CreateAsync(User user);
    Task<bool> IsEmailRegistered(string email);
}