
using System.Net;

namespace CurrencyExchange.Application.Common.Errors;

public class FailedLoginException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

    public string ErrorMessage => "Username or Password is incorrect";
}
