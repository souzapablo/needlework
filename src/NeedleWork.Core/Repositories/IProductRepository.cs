using NeedleWork.Core.Entities;

namespace NeedleWork.Core.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetAsync(string? searchTerm, string? sortColumn, string? sortOrder, int page, int pageSize);
    Task<Product?> GetByIdAsync(long id);
    Task CreateAsync(Product product);   
    Task UpdateAsync(Product product);
}