using System.Security.Claims;
using AspNetCoreRateLimit;

namespace CurrencyExchange.Api.Common.RateLimit;

public class QueryStringClientIdResolveContributor : IClientResolveContributor
{
    public Task<string> ResolveClientAsync(HttpContext httpContext)
    {
        var token = httpContext.Request.Headers["Authorization"];
        return Task.FromResult<string>(token);
    }
}
