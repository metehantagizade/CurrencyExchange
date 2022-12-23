using Microsoft.Extensions.Caching.Distributed;
using CurrencyExchange.Application.Common.Interfaces.Persistence;
using CurrencyExchange.Infrastructure.Helper;

namespace CurrencyExchange.Infrastructure.Persistence;

public class CacheRepository : ICacheRepository
{
    private IDistributedCache _cache;


    public CacheRepository(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task SetRecordAsync<T>(string recordId, T data)
    {
        await _cache.SetRecordAsync(recordId, data);
    }

    public async Task<T> GetRecordAsync<T>(string recordId)
    {
        return await _cache.GetRecordAsync<T>(recordId);
    }

}
