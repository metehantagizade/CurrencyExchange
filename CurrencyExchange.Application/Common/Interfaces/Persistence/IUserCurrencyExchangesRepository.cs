using CurrencyExchange.Domain.Entities;

namespace CurrencyExchange.Application.Common.Interfaces.Persistence;

public interface IUserCurrencyExchangesRepository
{
    void Add(UserCurrencyExchanges userCurrencyExchanges);
}
