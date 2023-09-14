using Microsoft.EntityFrameworkCore;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Repositories;

namespace NeedleWork.Infrastructure.Persistence.Repositories;
public class PurchaseRepository : IPurchaseRepository
{
    private readonly NeedleWorkDbContext _context;

    public PurchaseRepository(NeedleWorkDbContext context)
    {
        _context = context;
    }

    public async Task<Purchase?> GetByIdAsync(long id)
    {
        return await _context.Purchases
            .Include(x => x.Items)
            .ThenInclude(x => x.Product)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateAsync(Purchase purchase)
    {
        _context.Purchases.Add(purchase);
        await _context.SaveChangesAsync();
    }
}
