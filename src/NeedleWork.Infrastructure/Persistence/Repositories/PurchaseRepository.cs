using System.Linq.Expressions;
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

    public async Task<List<Purchase>> GetAsync(string? userId, string? sortColumn, string? sortOrder, int page, int pageSize)
    {
        IQueryable<Purchase> purchases = _context.Purchases;

        if (!string.IsNullOrWhiteSpace(userId))
        {
            purchases = purchases.Where(x =>
                x.UserId.ToString().Equals(userId));
        }

        if (sortOrder?.ToLower() == "desc")
        {
            purchases = purchases.OrderByDescending(GetSortProperty(sortColumn));
        }
        else
        {
            purchases = purchases.OrderBy(GetSortProperty(sortColumn));
        }

        return await purchases.ToListAsync();
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

    private static Expression<Func<Purchase, object>> GetSortProperty(string? sortColumn)
    {
        return sortColumn?.ToLower() switch
        {
            "total" => purchase => purchase.Total,
            "date" => purchase => purchase.PurchaseDate,
            "user" => purchase => purchase.UserId,
            _ => product => product.Id,
        }; ;
    }
}
