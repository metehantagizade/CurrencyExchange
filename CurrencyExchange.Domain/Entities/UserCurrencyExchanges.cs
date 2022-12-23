using System.ComponentModel.DataAnnotations.Schema;

namespace CurrencyExchange.Domain.Entities;

public class UserCurrencyExchanges
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public double Count { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public double Rate { get; set; }
    public double Result { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}
