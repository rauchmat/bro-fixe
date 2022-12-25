using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data;

public class DesignTimeBroFixeContextFactory : IDesignTimeDbContextFactory<BroFixeContext>
{
    private const string c_connectionString =
        "Application Name=BroFixe.Infrastructure;Integrated Security=SSPI;Initial Catalog=BroFixe_DEV;Data Source=localhost;TrustServerCertificate=True";

    public BroFixeContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BroFixeContext>();
        optionsBuilder.UseSqlServer(c_connectionString);
        return new BroFixeContext(optionsBuilder.Options);
    }
}