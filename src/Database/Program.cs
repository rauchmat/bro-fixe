using Autofac;
using Autofac.Extensions.DependencyInjection;
using BroFixe.Database.Extensions;
using BroFixe.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Constants = BroFixe.Database.Constants;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Configuring host ({ApplicationContext})...", Constants.AppName);
    var builder = Host.CreateDefaultBuilder(args);
    builder.UseSerilog();
    builder.ConfigureServices((context, services) =>
    {
        var config = context.Configuration;
        ConfigureOptions(config, services);
    });
    builder.UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureContainer<ContainerBuilder>(ConfigureContainer);
    var host = builder.Build();

    Log.Information("Applying migrations ({ApplicationContext})...", Constants.AppName);
    await host.ApplyMigrationsAndSeedData();

    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Program terminated unexpectedly ({ApplicationContext})!", Constants.AppName);
    return 1;
}
finally
{
    Log.CloseAndFlush();
}

void ConfigureOptions(IConfiguration configuration, IServiceCollection serviceCollection)
{
    serviceCollection.Configure<DataOptions>(configuration.GetSection(DataOptions.SectionName));
}

void ConfigureContainer(HostBuilderContext hostBuilderContext, ContainerBuilder containerBuilder)
{
    containerBuilder.RegisterAssemblyModules(typeof(DataModule).Assembly);
}