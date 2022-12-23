using Microsoft.Extensions.DependencyInjection;
using CurrencyExchange.Application.Common.Interfaces.Authentication;
using CurrencyExchange.Application.Common.Interfaces.Services;
using CurrencyExchange.Infrastructure.Authentication;
using CurrencyExchange.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using CurrencyExchange.Application.Common.Interfaces.Persistence;
using CurrencyExchange.Infrastructure.Persistence;
using CurrencyExchange.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using CurrencyExchange.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CurrencyExchange.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        var abc = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = configuration["JwtSettings:Audience"],
            ValidIssuer = configuration["JwtSettings:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Secret"]))
        };
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = abc;
        });
        services.AddDbContext<CurrencyExchangeDbContext>(opt => opt.UseSqlServer(
                                                             configuration.GetConnectionString("CurrencyExchangeConnection"),
                                                             opt => opt.MigrationsAssembly("CurrencyExchange.Infrastructure")));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserCurrencyExchangesRepository, UserCurrencyExchangesRepository>();
        services.AddScoped<ICacheRepository, CacheRepository>();
        services.AddSingleton<IFixerCurrencyProvider, FixerCurrencyProvider>();
        services.AddStackExchangeRedisCache(options => {
            options.Configuration = configuration.GetConnectionString("Redis");
            options.InstanceName = "RedisCurrencyExchange_";
        });
        return services;
    }
} 
