using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Repositories;

namespace NeedleWork.Infrastructure.Persistence.Repositories;

public class SupplierRepository : ISupplierRepository
{
    private readonly NeedleWorkDbContext _context;

    public SupplierRepository(NeedleWorkDbContext context)
    {
        _context = context;
    }

    public async Task<List<Supplier>> GetAsync(
        string? searchTerm,
        string? sortColumn,
        string? sortOrder,
        int page,
        int pageSize)
    {
        IQueryable<Supplier> suppliers = _context.Suppliers;

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            suppliers = suppliers.Where(x => 
                x.Name.Contains(searchTerm) ||
                x.Contact.Contains(searchTerm));
        }

        if (sortOrder?.ToLower() == "desc")
        {
            suppliers = suppliers.OrderByDescending(GetSortProperty(sortColumn));
        }
        else
        {
            suppliers = suppliers.OrderBy(GetSortProperty(sortColumn));
        }

        return await suppliers.ToListAsync();
    }

    public async Task CreateAsync(Supplier supplier)
    {
        _context.Suppliers.Add(supplier);
        await _context.SaveChangesAsync();
    }

    public async Task<Supplier?> GetByIdAsync(long Id)
    {
        return await _context.Suppliers
            .SingleOrDefaultAsync(x => x.Id == Id);
    }

    private static Expression<Func<Supplier, object>> GetSortProperty(string? sortColumn)
    {
        return sortColumn?.ToLower() switch
        {
            "name" => supplier => supplier.Name,
            _ => supplier => supplier.Id,
        };;
    }
}