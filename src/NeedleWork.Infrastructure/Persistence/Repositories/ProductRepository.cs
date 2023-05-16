using Microsoft.EntityFrameworkCore;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Models;
using NeedleWork.Core.Repositories;
using NeedleWork.Infrastructure.Extensions;
using System.Linq.Expressions;

namespace NeedleWork.Infrastructure.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly NeedleWorkDbContext _context;

    public ProductRepository(NeedleWorkDbContext context)
    {
        _context = context;
    }

    public async Task<PaginationResult<Product>> GetAllAsync(string? description, int page, int pageSize)
    {
        var products = _context.Products
            .Include(p => p.Supplier)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(description))
            products = products.Where(x => x.Description.ToLower()
            .Contains(description.ToLower()));

        return await products.GetPaged(page, pageSize);
    }

    public async Task<Product?> GetByIdAsync(long id, params Expression<Func<Product, object?>>[]? includes)
    {
        return await _context.Products
            .IncludeMultiple(includes)
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task CreateAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Update(product);
        await _context.SaveChangesAsync();
    }
}
