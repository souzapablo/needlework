using NeedleWork.Core.Entities;
using NeedleWork.Core.Models;
using System.Linq.Expressions;

namespace NeedleWork.Core.Repositories;
public interface IProductRepository
{
    Task<PaginationResult<Product>> GetAllAsync(string? description, int page, int pageSize);
    Task<Product?> GetByIdAsync(long id, params Expression<Func<Product, object?>>[]? includes);
    Task CreateAsync(Product product);
    Task UpdateAsync(Product product);
}
