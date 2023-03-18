using BroFixe.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BroFixe.Database.Extensions;

public static class DataExtensions
{
    public static async Task<IHost> ApplyMigrationsAndSeedData(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<BroFixeContext>();
        await db.Database.MigrateAsync();

        var seeder = new BroFixeContextSeed();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<BroFixeContextSeed>>();

        await seeder.SeedAsync(db, logger);
        return host;
    }
}