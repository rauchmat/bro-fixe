using Autofac;
using JetBrains.Annotations;

namespace BroFixe.Infrastructure.Data.Transactions;

[UsedImplicitly]
public class TransactionsModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<TransactionScopeService>().As<ITransactionScopeService>().InstancePerLifetimeScope();
  }
}