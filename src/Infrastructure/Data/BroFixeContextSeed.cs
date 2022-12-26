using BroFixe.Domain.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace BroFixe.Infrastructure.Data;

public class BroFixeContextSeed
{
    private static readonly Bro Mattl = new(nickname: "Mattl", email: "rauchmat@gmail.com", avatarUrl: "assets/mattl.jpg");
    private static readonly Bro Michl = new(nickname: "Michl", email: "meikkel@gmail.com", avatarUrl: "assets/michl.jpg");
    private static readonly Bro Mane = new(nickname: "Mane", email: "mane@gmail.com", avatarUrl: "assets/mane.jpg");

    public async Task SeedAsync(BroFixeContext context, IWebHostEnvironment env, ILogger<BroFixeContextSeed> logger)
    {
        if (!context.Bros.Any())
        {
            await context.Bros.AddRangeAsync(GetPreconfiguredBros());
            await context.SaveChangesAsync();
        }
        
        if (!context.Fixes.Any())
        {
            await context.Fixes.AddRangeAsync(GetPreconfiguredFixes());
            await context.SaveChangesAsync();
        }
    }

    private Bro[] GetPreconfiguredBros()
    {
        return new[]
        {
            Mattl,
            Michl,
            Mane,
        };
    }
    
    private Fixe[] GetPreconfiguredFixes()
    {
        return new[]
        {
            new Fixe("Bro Fixe Oktober 2022", "Gasthaus Stern", new DateTime(2022, 10, 17, 18, 30, 0), Michl, backgroundUrl: "assets/stern.jpg"),
            new Fixe("Bro Fixe November 2022", "Harry's Augustin", new DateTime(2022, 11, 12, 19, 0, 0), Mattl, backgroundUrl: "assets/harrys-augustin.jpg")
        };
    }
}