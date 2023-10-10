using System.Linq.Expressions;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NeedleWork.Application.Models.Users;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Repositories;

namespace NeedleWork.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly NeedleWorkDbContext _context;
    private readonly string _connectionString;

    public UserRepository(NeedleWorkDbContext context, IConfiguration configuration)
    {
        _context = context;
        _connectionString = configuration.GetConnectionString("NeedleWorkCs")!;
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
            .Include(x => x.Addresses)
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<UserLoginDTO?> GetByEmailAndPasswordAsync(string email, string password)
    {
        using SqlConnection sqlConnection = new SqlConnection(_connectionString);

        await sqlConnection.OpenAsync();

        string script = @"SELECT Id, Email, Role
                          FROM Users
                          WHERE Email = @email and Password = @password";

        return await sqlConnection.QuerySingleAsync<UserLoginDTO?>(
            script,
            new
            {
                email,
                password
            });
    }

    public async Task CreateAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> IsEmailRegistered(string email)
    {
        return await _context.Users
            .AnyAsync(x => x.Email.Equals(email));
    }

    public async Task<bool> VerifyIfExists(long id)
    {
        return await _context.Users
            .AnyAsync(x => x.Id == id);
    }

    private static Expression<Func<User, object>> GetSortProperty(string? sortColumn)
    {
        return sortColumn?.ToLower() switch
        {
            "first-name" => user => user.FirstName,
            "last-name" => user => user.LastName,
            "birth-date" => user => user.BirthDate,
            _ => user => user.Id,
        }; ;
    }


}