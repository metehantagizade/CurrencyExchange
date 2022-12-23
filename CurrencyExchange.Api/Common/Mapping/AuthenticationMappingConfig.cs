using Mapster;
using CurrencyExchange.Application.Authentication.Commands.Register;
using CurrencyExchange.Application.Authentication.Common;
using CurrencyExchange.Application.Authentication.Queries.Login;
using CurrencyExchange.Contracts.Authentication;

namespace CurrencyExchange.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest , src => src.User);
    }
}
