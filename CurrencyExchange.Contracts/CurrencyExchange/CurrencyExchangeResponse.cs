namespace CurrencyExchange.Contracts.CurrencyExchange;

public class CurrencyExchangeResponse
{
    public decimal Count { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public decimal Rate { get; set; }
    public decimal Result { get; set; }
}
