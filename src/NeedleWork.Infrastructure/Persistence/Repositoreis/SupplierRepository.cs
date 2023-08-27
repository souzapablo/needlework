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

    public async Task CreateAsync(Supplier supplier)
    {
        _context.Suppliers.Add(supplier);
        await _context.SaveChangesAsync();
    }
}