using CurrencyExchange.Application.Common.Interfaces.Services;

namespace CurrencyExchange.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
