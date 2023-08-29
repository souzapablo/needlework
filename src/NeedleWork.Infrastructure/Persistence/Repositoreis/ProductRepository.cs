using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
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

    public async Task<List<Product>> GetAsync(
        string? searchTerm, 
        string? sortColumn, 
        string? sortOrder, 
        int page, 
        int pageSize)
    {
        IQueryable<Product> products = _context.Products;

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            products = products.Where(x => 
                x.Description.Contains(searchTerm));
        }

        if (sortOrder?.ToLower() == "desc")
        {
            products = products.OrderByDescending(GetSortProperty(sortColumn));
        }
        else
        {
            products = products.OrderBy(GetSortProperty(sortColumn));
        }

        return await products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(long id)
    {
        return await _context.Products
            .Include(x => x.Supplier)
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task CreateAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }
    
    private static Expression<Func<Product, object>> GetSortProperty(string? sortColumn)
    {
        return sortColumn?.ToLower() switch
        {
            "description" => product => product.Description,
            "supplier" => product => product.SupplierId,
            "price" => product => product.Price,
            _ => product => product.Id,
        };;
    }
}