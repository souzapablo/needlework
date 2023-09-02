using NeedleWork.Core.Entities;

namespace NeedleWork.Core.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAsync(string? searchTerm, string? sortColumn, string? sortOrder, int page, int pageSize);
    Task<User?> GetByIdAsync(long id);
    Task CreateAsync(User user);
    Task UpdateAsync(User user);
    Task<bool> IsEmailRegistered(string email);
}