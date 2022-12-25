using BroFixe.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BroFixe.Infrastructure.Data;

public class BroFixeContext : DbContext
{
    public BroFixeContext(DbContextOptions<BroFixeContext> options) : base(options)
    {
    }

    public DbSet<Bro> Bros { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}