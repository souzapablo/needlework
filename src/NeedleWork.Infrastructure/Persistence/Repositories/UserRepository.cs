using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Repositories;

namespace NeedleWork.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly NeedleWorkDbContext _context;

    public UserRepository(NeedleWorkDbContext context)
    {
        _context = context;
    }
    
    public Task<List<User>> GetAsync(string? searchTerm, string? sortColumn, string? sortOrder, int page, int pageSize)
    {
        IQueryable<User> users = _context.Users;
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            users = users.Where(x => 
                x.FirstName.Contains(searchTerm) ||
                x.LastName.Contains(searchTerm));
        }

        if (sortOrder?.ToLower() == "desc")
        {
            users = users.OrderByDescending(GetSortProperty(sortColumn));
        }
        else
        {
            users = users.OrderBy(GetSortProperty(sortColumn));
        }            

        return users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(long id)
    {
        return await _context.Users
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> IsEmailRegistered(string email)
    {
        return await _context.Users
            .AnyAsync(x => x.Email.Equals(email));
    }

    private static Expression<Func<User, object>> GetSortProperty(string? sortColumn)
    {
        return sortColumn?.ToLower() switch
        {
            "first-name" => user => user.FirstName,
            "last-name" => user => user.LastName,
            "birth-date" => user => user.BirthDate,
            _ => user => user.Id,
        };;
    }
}