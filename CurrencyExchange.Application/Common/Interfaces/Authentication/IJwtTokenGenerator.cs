
using CurrencyExchange.Domain.Entities;

namespace CurrencyExchange.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}

