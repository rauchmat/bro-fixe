using BroFixe.Domain.Model;
using BroFixe.Infrastructure.PushNotifications;
using Microsoft.EntityFrameworkCore;

namespace BroFixe.Infrastructure.Data;

public class BroFixeContext : DbContext
{
    public BroFixeContext(DbContextOptions<BroFixeContext> options) : base(options)
    {
    }

    public DbSet<Bro> Bros => Set<Bro>();
    public DbSet<Fixe> Fixes => Set<Fixe>();
    
    public DbSet<PersistentPushSubscription> PushSubscriptions => Set<PersistentPushSubscription>();

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