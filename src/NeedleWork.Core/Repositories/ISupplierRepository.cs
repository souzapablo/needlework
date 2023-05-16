using NeedleWork.Application.Models;
using NeedleWork.Core.Entities;
using System.Linq.Expressions;

namespace NeedleWork.Application.Repositories;

public interface ISupplierRepository
{
    Task<PaginationResult<Supplier>> GetAllAsync(string? name, int page, int pageSize);
    Task<Supplier?> GetByIdAsync(long id, params Expression<Func<Supplier, object?>>[]? includes);
    Task CreateAsync(Supplier supplier);
    Task UpdateAsync(Supplier supplier);
}
