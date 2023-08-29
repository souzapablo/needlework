using NeedleWork.Core.Entities;

namespace NeedleWork.Core.Repositories;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(long id);
    Task CreateAsync(Product product);   
}