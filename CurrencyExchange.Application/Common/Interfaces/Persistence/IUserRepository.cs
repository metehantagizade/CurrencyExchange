using CurrencyExchange.Domain.Entities;

namespace CurrencyExchange.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User GetUserByEmail(string email);
    void Add(User user);
}
