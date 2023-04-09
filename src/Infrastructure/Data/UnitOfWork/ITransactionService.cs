using System.Transactions;

namespace BroFixe.Infrastructure.Data.UnitOfWork;

public interface ITransactionService
{
    TransactionScope EnterTransactionScope();
}