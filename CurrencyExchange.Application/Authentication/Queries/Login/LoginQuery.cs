using MediatR;
using CurrencyExchange.Application.Authentication.Common;

namespace CurrencyExchange.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<AuthenticationResult>;
