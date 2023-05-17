using NeedleWork.Core.Entities;
using System.Linq.Expressions;

namespace NeedleWork.Core.Repositories;
public interface IUserRepository
{
    IEnumerable<User> GetAll();
    Task<User?> GetByIdAsync(long id, params Expression<Func<User, object?>>[]? includes);
    Task<bool> CheckIfUserExists(string email);
    Task CreateAsync(User user);
    Task UpdateAsync(User user);
}
