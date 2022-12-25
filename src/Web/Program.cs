using Autofac;
using Autofac.Extensions.DependencyInjection;
using BroFixe.Web;
using BroFixe.Web.Extensions;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
try
{
    Log.Information("Configuring web host ({ApplicationContext})...", Constants.AppName);
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog();
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureContainer<ContainerBuilder>(containerBuilder =>
        {
            //containerBuilder.RegisterModule<>();
        });

// Add services to the container.

    builder.Services.AddDbContext<BroFixeContext>(options =>
        options.UseSqlServer(builder.Configuration["Data:ConnectionString"]));
    builder.Services.AddControllersWithViews();
    builder.Services.AddSwaggerDocument();
    

    var app = builder.Build();

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