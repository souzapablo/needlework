using NeedleWork.Core.Entities;

namespace NeedleWork.Core.Repositories;

public interface IProductRepository
{
    Task CreateAsync(Product product);   
}