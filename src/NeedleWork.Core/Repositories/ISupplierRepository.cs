using NeedleWork.Application.Models;
using NeedleWork.Core.Entities;

namespace NeedleWork.Application.Repositories;

public interface ISupplierRepository
{
    Task<PaginationResult<Supplier>> GetAllAsync(string? name, int page, int pageSize);
}
