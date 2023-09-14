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

    public async Task CreateAsync(Purchase purchase)
    {
        _context.Purchases.Add(purchase);
        await _context.SaveChangesAsync();
    }
}
