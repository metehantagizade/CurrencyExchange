using System.Net;

namespace CurrencyExchange.Application.Common.Errors;

public interface IServiceException
{
    public HttpStatusCode StatusCode { get;}
    public string ErrorMessage { get; }
}
