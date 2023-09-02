using Microsoft.EntityFrameworkCore;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Repositories;

namespace NeedleWork.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NeedleWorkDbContext _context;

        public UserRepository(NeedleWorkDbContext context)
        {
            _context = context;
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
    }
}