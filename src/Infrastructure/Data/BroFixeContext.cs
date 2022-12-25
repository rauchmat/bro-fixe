using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Data;

public class BroFixeContext : DbContext
{
    public BroFixeContext(DbContextOptions<BroFixeContext> options) : base(options)
    {
    }

    public DbSet<Bro> Bros { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}