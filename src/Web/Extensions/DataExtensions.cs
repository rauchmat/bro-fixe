﻿using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BroFixe.Web.Extensions;

public static class DataExtensions
{
    public static async Task<WebApplication> ApplyMigrationsAndSeedData(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<BroFixeContext>();
        await db.Database.MigrateAsync();

        var seeder = new BroFixeContextSeed();
        var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<BroFixeContextSeed>>();

        await seeder.SeedAsync(db, env, logger);
        return app;
    }
}