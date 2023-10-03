using Microsoft.Extensions.Caching.Distributed;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Repositories;
using NeedleWork.Infrastructure.Extensions;
using Newtonsoft.Json;

namespace NeedleWork.Infrastructure.Persistence.Repositories;

public class CachedSupplierRepository : ISupplierRepository
{
    private readonly SupplierRepository _decorated;
    private readonly IDistributedCache _distributedCache;
    private readonly NeedleWorkDbContext _context;
    public CachedSupplierRepository(SupplierRepository decorated, IDistributedCache distributedCache, NeedleWorkDbContext context)
    {
        _decorated = decorated;
        _distributedCache = distributedCache;
        _context = context;
    }
    public Task CreateAsync(Supplier supplier) => _decorated.CreateAsync(supplier);

    public Task<List<Supplier>> GetAsync(string? searchTerm, string? sortColumn, string? sortOrder, int page, int pageSize) =>
        GetAsync(searchTerm, sortColumn, sortOrder, page, pageSize);

    public async Task<Supplier?> GetByIdAsync(long id)
    {
        string key = $"supplier:{id}:json";

        string? cachedSupplier = await _distributedCache.GetStringAsync(key);
        
        Supplier? supplier;
        
        if (string.IsNullOrWhiteSpace(cachedSupplier))
        {
            supplier = await _decorated.GetByIdAsync(id);

            if (supplier is null)
                return supplier;

            await _distributedCache.SetStringAsync(
                key,
                JsonConvert.SerializeObject(supplier)
            );

            return supplier;
        }

        supplier = JsonConvert.DeserializeObject<Supplier>(
            cachedSupplier,
            new JsonSerializerSettings{
                ConstructorHandling = 
                    ConstructorHandling.AllowNonPublicDefaultConstructor,
                    ContractResolver = new PrivateResolver()
                });

        if (supplier is not null)
            _context.Set<Supplier>().Attach(supplier);
    
        return supplier;
    }

    public Task UpdateAsync(Supplier supplier) => _decorated.UpdateAsync(supplier);

    public Task<bool> VerifyIfExists(long id) => _decorated.VerifyIfExists(id);

}