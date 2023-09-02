using NeedleWork.Core.Entities;

namespace NeedleWork.Core.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(long id);
    Task CreateAsync(User user);
    Task<bool> IsEmailRegistered(string email);
}