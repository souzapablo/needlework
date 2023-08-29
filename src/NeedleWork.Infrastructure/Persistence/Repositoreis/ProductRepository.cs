using NeedleWork.Core.Entities;
using NeedleWork.Core.Repositories;

namespace NeedleWork.Infrastructure.Persistence.Repositoreis;

public class ProductRepository : IProductRepository
{
    private readonly NeedleWorkDbContext _context;

    public ProductRepository(NeedleWorkDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }
}