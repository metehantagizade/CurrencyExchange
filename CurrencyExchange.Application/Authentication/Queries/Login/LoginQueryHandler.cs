using MediatR;
using CurrencyExchange.Application.Authentication.Common;
using CurrencyExchange.Application.Common.Errors;
using CurrencyExchange.Application.Common.Interfaces.Authentication;
using CurrencyExchange.Application.Common.Interfaces.Persistence;
using CurrencyExchange.Domain.Entities;

namespace CurrencyExchange.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            throw new FailedLoginException();
        }
        if (user.Password != query.Password)
        {
            throw new FailedLoginException();
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
