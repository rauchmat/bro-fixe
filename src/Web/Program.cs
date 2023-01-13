using Autofac;
using Autofac.Extensions.DependencyInjection;
using BroFixe.Infrastructure.Data;
using BroFixe.Web.Extensions;
using BroFixe.Web.Infrastructure.OpenApi;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Core;
using Constants = BroFixe.Web.Constants;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Configuring web host ({ApplicationContext})...", Constants.AppName);
    var builder = WebApplication.CreateBuilder(args);
    Log.Logger = CreateLoggerConfiguration(builder).CreateLogger();
    builder.Host.UseSerilog();
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureContainer<ContainerBuilder>(containerBuilder =>
        {
            //containerBuilder.RegisterModule<>();
        });

    // Add services to the container.

    var connectionString = builder.Configuration["Data:ConnectionString"];
    Log.Logger.Information("Using ConnectionString {ConnectionString}", connectionString);

    builder.Services.AddDbContext<BroFixeContext>(options => options.UseSqlServer(connectionString));
    builder.Services.AddControllersWithViews();
    builder.Services.AddSwaggerDocument();
    builder.Services.ConfigureSwagger(WebOpenApiDefinitions.All);


    var app = builder.Build();


    if (ShouldGenerateApiClients(args))
    {
        await OpenApiGenerator.GenerateApiClients(args[1], args[2], app);
        return 0;
    }

// Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseSerilogRequestLogging();
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseOpenApi();
    app.UseSwaggerUi3();
    app.UseRouting();


    app.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");

    app.MapFallbackToFile("index.html");

    Log.Information("Applying migrations ({ApplicationContext})...", Constants.AppName);
    await app.ApplyMigrationsAndSeedData();

    app.Run();
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

bool ShouldGenerateApiClients(IReadOnlyList<string> args)
{
    return args.Count > 0 && args[0] == "generate-api-clients";
}

LoggerConfiguration CreateLoggerConfiguration(WebApplicationBuilder webApplicationBuilder)
{
    var loggerConfiguration = new LoggerConfiguration()
        .WriteTo.Console();

    var seqUrl = webApplicationBuilder.Configuration["Logging:SeqUrl"];
    if (seqUrl != null)
        loggerConfiguration.WriteTo.Seq(seqUrl);

    return loggerConfiguration;
}