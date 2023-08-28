using NeedleWork.Core.Entities;

namespace NeedleWork.Core.Repositories;

public interface ISupplierRepository
{
    Task<List<Supplier>> GetAllAsync(string? searchTerm, string? sortColumn, string? sortOrder);
    Task<Supplier?> GetByIdAsync(long Id);
    Task CreateAsync(Supplier supplier);
}