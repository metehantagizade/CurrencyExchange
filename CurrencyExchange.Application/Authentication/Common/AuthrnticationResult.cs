using CurrencyExchange.Domain.Entities;

namespace CurrencyExchange.Application.Authentication.Common;

public record AuthenticationResult(
                        User User,
                        string Token);
