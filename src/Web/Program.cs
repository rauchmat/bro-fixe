using Autofac;
using Autofac.Extensions.DependencyInjection;
using BroFixe.Infrastructure.Data;
using BroFixe.Infrastructure.PushNotifications;
using BroFixe.Web;
using BroFixe.Web.Infrastructure.OpenApi;
using BroFixe.Web.Infrastructure.UnitOfWork;
using Lib.Net.Http.WebPush;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using NSwag;
using NSwag.Generation.Processors.Security;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Configuring web host ({ApplicationContext})...", Constants.AppName);
    var builder = WebApplication.CreateBuilder(args);
    Log.Logger = CreateLoggerConfiguration(builder).CreateLogger();
    builder.Host.UseSerilog();
    builder.Host.ConfigureServices((context, services) =>
    {
        var config = context.Configuration;
        ConfigureOptions(config, services);
    });
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureContainer<ContainerBuilder>(ConfigureContainer);
    builder.Host.ConfigureServices(ConfigureServices);

    var dataOptions = new DataOptions();
    builder.Configuration.GetRequiredSection(DataOptions.SectionName).Bind(dataOptions);
    Log.Logger.Information("Using ConnectionString {ConnectionString}", dataOptions.ConnectionString);

    builder.Services.AddDbContext<BroFixeContext>(options => options.UseSqlServer(dataOptions.ConnectionString));
    builder.Services.AddControllersWithViews();
    builder.Services.AddSwaggerDocument(document =>
    {
        document.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT"));
        document.DocumentProcessors.Add(new SecurityDefinitionAppender("JWT", new OpenApiSecurityScheme
        {
            Type = OpenApiSecuritySchemeType.ApiKey,
            Name = "Authorization",
            In = OpenApiSecurityApiKeyLocation.Header,
            Description = "Insert your JWT."
        }));

    });
    builder.Services.ConfigureSwagger(WebOpenApiDefinitions.All);
    builder.Services.AddHttpClient<PushServiceClient>();

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
    app.UseMiddleware<UnitOfWorkMiddleware>();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");

    app.MapFallbackToFile("index.html");

    await app.RunAsync();
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

void ConfigureOptions(IConfiguration configuration, IServiceCollection serviceCollection)
{
    serviceCollection.Configure<DataOptions>(configuration.GetSection(DataOptions.SectionName));
    serviceCollection.Configure<PushNotificationsOptions>(
        configuration.GetSection(PushNotificationsOptions.SectionName));
}

void ConfigureContainer(HostBuilderContext hostBuilderContext, ContainerBuilder containerBuilder)
{
    containerBuilder.RegisterAssemblyModules(typeof(DataModule).Assembly);
}

void ConfigureServices(HostBuilderContext context, IServiceCollection services)
{
    services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

    }).AddJwtBearer(options =>
    {
        options.Authority = context.Configuration["JwtBearer:Authority"];
        options.Audience = context.Configuration["JwtBearer:Audience"];
    });
}