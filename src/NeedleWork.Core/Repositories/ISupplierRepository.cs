using NeedleWork.Core.Entities;

namespace NeedleWork.Core.Repositories;

public interface ISupplierRepository
{
    Task<Supplier?> GetByIdAsync(long Id);
    Task CreateAsync(Supplier supplier);
}