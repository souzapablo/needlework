using NeedleWork.Core.Entities;

namespace NeedleWork.Core.Repositories;

public interface ISupplierRepository
{
    Task<List<Supplier>> GetAllAsync();
    Task<Supplier?> GetByIdAsync(long Id);
    Task CreateAsync(Supplier supplier);
}