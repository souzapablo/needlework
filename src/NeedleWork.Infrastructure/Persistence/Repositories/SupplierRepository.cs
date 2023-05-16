using Microsoft.EntityFrameworkCore;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Models;
using NeedleWork.Core.Repositories;
using NeedleWork.Infrastructure.Extensions;
using System.Linq.Expressions;

namespace NeedleWork.Infrastructure.Persistence.Repositories;

public class SupplierRepository : ISupplierRepository
{
    private readonly NeedleWorkDbContext _context;

    public SupplierRepository(NeedleWorkDbContext context)
    {
        _context = context;
    }

    public async Task<PaginationResult<Supplier>> GetAllAsync(string? name, int page, int pageSize)
    {
        var suppliers = _context.Suppliers
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(name)) 
            suppliers = suppliers.Where(x => x.Name.ToLower()
            .Contains(name.ToLower()));

        return await suppliers.GetPaged(page, pageSize);
    }

    public async Task<Supplier?> GetByIdAsync(long id, params Expression<Func<Supplier, object?>>[]? includes)
    {
        return await _context.Suppliers
            .IncludeMultiple(includes)
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task CreateAsync(Supplier supplier)
    {
        await _context.Suppliers
            .AddAsync(supplier);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Supplier supplier)
    {
        _context.Suppliers
            .Update(supplier);
        await _context.SaveChangesAsync();
    }
}
