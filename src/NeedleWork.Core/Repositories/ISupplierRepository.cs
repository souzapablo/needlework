using NeedleWork.Core.Entities;
using NeedleWork.Core.Models;
using System.Linq.Expressions;

namespace NeedleWork.Core.Repositories;

public interface ISupplierRepository
{
    Task<PaginationResult<Supplier>> GetAllAsync(string? name, int page, int pageSize);
    Task<Supplier?> GetByIdAsync(long id, params Expression<Func<Supplier, object?>>[]? includes);
    Task CreateAsync(Supplier supplier);
    Task UpdateAsync(Supplier supplier);
}
