
using Autofac;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BroFixe.Infrastructure.Data;

[UsedImplicitly]
public class DataModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.Register(context =>
        {
            var optionsBuilder = new DbContextOptionsBuilder<BroFixeContext>();
            var dataOptions = context.Resolve<IOptions<DataOptions>>().Value;
            optionsBuilder.UseSqlServer(dataOptions.ConnectionString);
            return optionsBuilder.Options;
        });
        builder.RegisterType<BroFixeContext>().InstancePerLifetimeScope();
    }
}