using NeedleWork.Core.Entities;

namespace NeedleWork.Core.Repositories;
public interface IPurchaseRepository
{
    Task CreateAsync(Purchase purchase);
    Task<Purchase?> GetByIdAsync(long id);
}
