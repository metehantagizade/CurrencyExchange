using AspNetCoreRateLimit;
using CurrencyExchange.Api;
using CurrencyExchange.Api.Middleware;
using CurrencyExchange.Application;
using CurrencyExchange.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
            .AddPresentation()
            .AddApplication()
            .AddInfrastructure(builder.Configuration);
    //builder.Host.UseSerilog();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseMiddleware<RequestResponseLogMiddleware>();
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseClientRateLimiting();

    app.MapControllers();

    app.Run();
}

