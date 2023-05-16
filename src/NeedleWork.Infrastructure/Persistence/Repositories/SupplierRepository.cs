using NeedleWork.Application.Models;
using NeedleWork.Application.Repositories;
using NeedleWork.Core.Entities;
using NeedleWork.Infrastructure.Extensions;

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

    public async Task CreateAsync(Supplier supplier)
    {
        await _context.Suppliers
            .AddAsync(supplier);
        await _context.SaveChangesAsync();
    }
}
