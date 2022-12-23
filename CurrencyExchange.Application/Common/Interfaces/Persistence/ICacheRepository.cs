namespace CurrencyExchange.Application.Common.Interfaces.Persistence;

public interface ICacheRepository
{
    Task SetRecordAsync<T>(string recordId, T data);
    Task<T> GetRecordAsync<T>(string recordId);
}
