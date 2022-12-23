using CurrencyExchange.Application.Common.Interfaces.Persistence;
using CurrencyExchange.Domain.Entities;
using CurrencyExchange.Infrastructure.Context;

namespace CurrencyExchange.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly CurrencyExchangeDbContext _currencyexchangeDbContext;

    public UserRepository(CurrencyExchangeDbContext currencyexchangeDbContext)
    {
        _currencyexchangeDbContext = currencyexchangeDbContext;
    }
    public void Add(User user)
    {
        _currencyexchangeDbContext.Users.Add(user);
        _currencyexchangeDbContext.SaveChanges();
    }

    public User GetUserByEmail(string email)
    {
        return _currencyexchangeDbContext.Users.SingleOrDefault(w => w.Email == email);
    }
}
