using NeedleWork.Core.Entities;

namespace NeedleWork.Core.Repositories;

public interface ISupplierRepository
{
    Task CreateAsync(Supplier supplier);
}