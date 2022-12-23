namespace CurrencyExchange.Application.CurrencyExchange.Common;

public class ExchangeResult
{
    public double Count { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public double Rate { get; set; }
    public double Result { get; set; }
    public int UserId { get; set; }
}

