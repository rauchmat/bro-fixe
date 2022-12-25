using BroFixe.Domain.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace BroFixe.Infrastructure.Data;

public class BroFixeContextSeed
{
    public async Task SeedAsync(BroFixeContext context, IWebHostEnvironment env, ILogger<BroFixeContextSeed> logger)
    {
        if (!context.Bros.Any())
        {
            await context.Bros.AddRangeAsync(GetPreconfiguredBros());
            await context.SaveChangesAsync();
        }
    }

    private Bro[] GetPreconfiguredBros()
    {
        return new[]
        {
            new Bro {Id = Guid.NewGuid(), Nickname = "Mattl", Email = "rauchmat@gmail.com", AvatarUrl = ""},
            new Bro {Id = Guid.NewGuid(), Nickname = "Michl", Email = "meikkel@gmail.com", AvatarUrl = ""},
            new Bro {Id = Guid.NewGuid(), Nickname = "Mane", Email = "mane@gmail.com", AvatarUrl = ""},
        };
    }
}