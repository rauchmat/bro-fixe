using Autofac;
using JetBrains.Annotations;

namespace BroFixe.Infrastructure.Data.UnitOfWork;

[UsedImplicitly]
public class UnitOfWorkModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
    builder.RegisterType<CompensatingActionsRegistry>().As<ICompensatingActionsRegistry>().InstancePerLifetimeScope();
  }
}