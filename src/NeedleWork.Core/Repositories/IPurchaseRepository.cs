using NeedleWork.Core.Entities;

namespace NeedleWork.Core.Repositories;
public interface IPurchaseRepository
{
    Task<List<Purchase>> GetAsync(string? userId, string? sortColumn, string? sortOrder, int page, int pageSize);
    Task<Purchase?> GetByIdAsync(long id);
    Task CreateAsync(Purchase purchase);
    Task UpdateAsync(Purchase purchase);
}
