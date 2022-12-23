namespace CurrencyExchange.Api.Common.Models;

public class LogModel
{
    public string Scheme { get; set; }
    public string Host { get; set; }
    public string Path { get; set; }
    public string QueryString { get; set; }
    public int StatusCode { get; set; }
    public string RequestBody { get; set; }
    public string ResponseBody { get; set; }
    public string ContentLength { get; set; }
}
