using Microsoft.EntityFrameworkCore;
using CurrencyExchange.Domain.Entities;

namespace CurrencyExchange.Infrastructure.Context;

public class CurrencyExchangeDbContext : DbContext
{
    public CurrencyExchangeDbContext(DbContextOptions<CurrencyExchangeDbContext> options): base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<UserCurrencyExchanges> UserCurrencyExchanges { get; set; }
}
