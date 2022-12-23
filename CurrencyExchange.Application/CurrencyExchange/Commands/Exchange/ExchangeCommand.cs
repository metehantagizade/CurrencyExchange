using MediatR;
using CurrencyExchange.Application.CurrencyExchange.Common;

namespace CurrencyExchange.Application.CurrencyExchange.Commands.Exchange;

public class ExchangeCommand : IRequest<ExchangeResult>
{
    public double Count { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public int UserId { get; set; }
}
