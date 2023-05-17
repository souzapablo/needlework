using Microsoft.EntityFrameworkCore;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Repositories;
using NeedleWork.Infrastructure.Extensions;
using System.Linq.Expressions;

namespace NeedleWork.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly NeedleWorkDbContext _context;

    public UserRepository(NeedleWorkDbContext context)
    {
        _context = context;
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users;
    }

    public async Task<User?> GetByIdAsync(long id, params Expression<Func<User, object?>>[]? includes)
    {
        return await _context.Users
            .IncludeMultiple(includes)
            .AsNoTracking()
            .SingleOrDefaultAsync(u => u.Id == id);
    }

    public async Task<bool> CheckIfUserExists(string email)
    {
        return await _context.Users
            .AnyAsync(u => u.Email == email);
    }

    public async Task CreateAsync(User user)
    {
        await _context.Users
            .AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _context.Update(user);
        await _context.SaveChangesAsync();
    }
}
