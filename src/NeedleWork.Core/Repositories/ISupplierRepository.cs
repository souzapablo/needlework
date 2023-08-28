using NeedleWork.Core.Entities;
using NeedleWork.Infrastructure.Shared;

namespace NeedleWork.Core.Repositories;

public interface ISupplierRepository
{
    Task<List<Supplier>> GetAsync(string? searchTerm, string? sortColumn, string? sortOrder, int page, int pageSize);
    Task<Supplier?> GetByIdAsync(long Id);
    Task CreateAsync(Supplier supplier);
    Task UpdateAsync(Supplier supplier);
}