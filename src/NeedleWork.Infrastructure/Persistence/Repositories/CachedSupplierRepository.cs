using Microsoft.Extensions.Caching.Memory;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Repositories;

namespace NeedleWork.Infrastructure.Persistence.Repositories;

public class CachedSupplierRepository : ISupplierRepository
{
    private readonly SupplierRepository _decorated;
    private readonly IMemoryCache _memoryCache;
    public CachedSupplierRepository(SupplierRepository decorated, IMemoryCache memoryCache)
    {
        _decorated = decorated;
        _memoryCache = memoryCache;
    }
    public Task CreateAsync(Supplier supplier) => _decorated.CreateAsync(supplier);

    public Task<List<Supplier>> GetAsync(string? searchTerm, string? sortColumn, string? sortOrder, int page, int pageSize) =>
        GetAsync(searchTerm, sortColumn, sortOrder, page, pageSize);

    public Task<Supplier?> GetByIdAsync(long id)
    {
        string key = $"supplier-{id}";

        return _memoryCache.GetOrCreateAsync(
            key,
            entry => 
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                return _decorated.GetByIdAsync(id);
            }
        );
    }

    public Task UpdateAsync(Supplier supplier) => _decorated.UpdateAsync(supplier);

    public Task<bool> VerifyIfExists(long id) => _decorated.VerifyIfExists(id);

}