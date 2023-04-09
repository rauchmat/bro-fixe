using System.Transactions;

namespace BroFixe.Infrastructure.Data.Transactions;

public static class TransactionScopeFactory
{
  public static (TransactionScope, Transaction) Create(TransactionScopeOption scopeOption)
  {
    var transactionOptions = new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted };
    var transactionScope =
      new TransactionScope(scopeOption, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);

    if (Transaction.Current == null)
      throw new Exception("Failed to create transaction.");

    return (transactionScope, Transaction.Current);
  }
}