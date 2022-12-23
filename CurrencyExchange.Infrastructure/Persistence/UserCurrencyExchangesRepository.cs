using CurrencyExchange.Application.Common.Interfaces.Persistence;
using CurrencyExchange.Domain.Entities;
using CurrencyExchange.Infrastructure.Context;

namespace CurrencyExchange.Infrastructure.Persistence;

public class UserCurrencyExchangesRepository : IUserCurrencyExchangesRepository
{
    private readonly CurrencyExchangeDbContext _currencyexchangeDbContext;

    public UserCurrencyExchangesRepository(CurrencyExchangeDbContext currencyexchangeDbContext)
    {
        _currencyexchangeDbContext = currencyexchangeDbContext;
    }
    public void Add(UserCurrencyExchanges userCurrencyExchanges)
    {
        _currencyexchangeDbContext.UserCurrencyExchanges.Add(userCurrencyExchanges);
        _currencyexchangeDbContext.SaveChanges();
    }
}
