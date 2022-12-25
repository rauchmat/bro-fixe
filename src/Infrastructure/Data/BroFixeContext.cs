using BroFixe.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BroFixe.Infrastructure.Data;

public class BroFixeContext : DbContext
{
    public BroFixeContext(DbContextOptions<BroFixeContext> options) : base(options)
    {
    }

    public DbSet<Bro> Bros => Set<Bro>();
    public DbSet<Fixe> Fixes => Set<Fixe>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Fixe>()
            .HasOne(p => p.Organizer)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}