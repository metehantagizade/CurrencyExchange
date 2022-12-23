
using MediatR;
using CurrencyExchange.Application.Authentication.Common;

namespace CurrencyExchange.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<AuthenticationResult>;
