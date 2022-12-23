namespace CurrencyExchange.Application.Common.Interfaces.Services;

public interface IFixerCurrencyProvider
{
    string GetLatest(string currencyCode);
}
