using System.Data.Common;
using Autofac;
using BroFixe.Infrastructure.Data.Transactions;
using JetBrains.Annotations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BroFixe.Infrastructure.Data;

[UsedImplicitly]
public class DataModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.Register<DbConnection>(
                ctx =>
                {
                    var transactionScopeService = ctx.Resolve<ITransactionScopeService>();

                    var connectionString = ctx.Resolve<IOptions<DataOptions>>().Value.ConnectionString;

                    var transaction = transactionScopeService.EnterScope();

                    var connection = new SqlConnection(connectionString);
                    connection.Open();

                    if (transaction != null)
                        connection.EnlistTransaction(transaction);

                    return connection;
                })
            .InstancePerLifetimeScope();

        builder.Register(
            ctx =>
            {
                var connection = ctx.Resolve<DbConnection>();
                var optionsBuilder = new DbContextOptionsBuilder<BroFixeContext>().UseSqlServer(connection);

                return optionsBuilder.Options;
            });

        builder.RegisterType<BroFixeContext>().InstancePerLifetimeScope();
    }
}