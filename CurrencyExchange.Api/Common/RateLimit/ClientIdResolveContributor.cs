using System.Security.Claims;
using AspNetCoreRateLimit;

namespace CurrencyExchange.Api.Common.RateLimit;

public class ClientIdResolveContributor : IClientResolveContributor
{
    public Task<string> ResolveClientAsync(HttpContext httpContext)
    {
        string userId = "";
        var identity = httpContext.User.Identity as ClaimsIdentity;
        if (identity != null)
        {
            IEnumerable<Claim> claims = identity.Claims;
            userId = identity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
        Console.WriteLine(userId);
        return Task.FromResult(userId);
    }
}
