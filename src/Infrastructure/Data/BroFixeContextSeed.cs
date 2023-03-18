using BroFixe.Domain.Model;
using Microsoft.Extensions.Logging;

namespace BroFixe.Infrastructure.Data;

public class BroFixeContextSeed
{
    private static readonly Bro Mattl = new(nickname: "Mattl", email: "rauchmat@gmail.com",
        avatarUrl: "assets/mattl.jpg");

    private static readonly Bro Eichi = new(nickname: "Eichi", email: "mario.eichinger86@gmail.com",
        avatarUrl: "assets/eichi.png");

    private static readonly Bro Hirschi = new(nickname: "Hirschi", email: "m.hirschbeck@gmx.net", avatarUrl: "assets/hirschi.png");

    public async Task SeedAsync(BroFixeContext context, ILogger<BroFixeContextSeed> logger)
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

    private IEnumerable<Bro> GetPreconfiguredBros()
    {
        yield return Mattl;
        yield return new(nickname: "Michl", email: "meikel.schoen@gmail.com", avatarUrl: "assets/michl.jpg");
        yield return new(nickname: "Mane", email: "manuel.schierl@gmail.com", avatarUrl: "assets/mane.png");
        yield return new(nickname: "Tiefi", email: "tiefi1985@gmail.com", avatarUrl: "assets/tiefi.jpg");
        yield return new(nickname: "Flo", email: "f.kucher@gmx.at", avatarUrl: "assets/flo.jpg");
        yield return Eichi;
        yield return new(nickname: "Mini", email: "matthias.minarik@chello.at", avatarUrl: "assets/mini.jpg");
        yield return Hirschi;
        yield return new(nickname: "Xandl", email: "alex_gross@gmx.at", avatarUrl: "assets/xandl.jpg");
    }

    private IEnumerable<Fixe> GetPreconfiguredFixes()
    {
        yield return new Fixe("Februar 2023", "Ebi", new DateTime(2023, 02, 23, 19, 0, 0),
            Eichi, backgroundUrl: "assets/fixe-2023-02.jpg");
        yield return new Fixe("Dezember 2022 - Weihnachtsfeier", "Addicted to Rock Bar & Burger", new DateTime(2022, 12, 22, 18, 0, 0),
            Mattl, backgroundUrl: "assets/addicted-to-rock.jpg");
        yield return new Fixe("Oktober 2022 - Gansl Special", "Harry's Augustin", new DateTime(2022, 10, 27, 19, 0, 0),
            Eichi, backgroundUrl: "assets/harrys-augustin.jpg");
        yield return new Fixe("September 2022 - Corona Relaunch", "El Gaucho Rochusmark", new DateTime(2022, 09, 22, 19, 15, 0),
            Hirschi, backgroundUrl: "assets/fixe-2022-09.jpg");
    }
}