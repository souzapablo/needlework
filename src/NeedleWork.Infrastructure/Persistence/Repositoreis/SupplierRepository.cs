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

    public async Task<List<Supplier>> GetAllAsync()
    {
        return await _context.Suppliers
            .ToListAsync();
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
}