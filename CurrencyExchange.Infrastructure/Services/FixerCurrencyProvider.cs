using RestSharp;
using CurrencyExchange.Application.Common.Interfaces.Services;

namespace CurrencyExchange.Infrastructure.Services;

public class FixerCurrencyProvider : IFixerCurrencyProvider
{
    public string GetLatest(string currencyCode)
    {
        var client = new RestClient("https://api.apilayer.com/fixer/latest?base=EUR");

        var request = new RestRequest();
        request.AddHeader("apikey", "G5suonb4q8HLb32fSqQ0PM0i8oBrCcUw");

        var response = client.Execute(request);
        return response.Content;
    }
}
