using System.Transactions;

namespace BroFixe.Infrastructure.Data.Transactions;

public class NullTransactionScopeService : ITransactionScopeService
{
  public Transaction? EnterScope()
  {
    return null;
  }

  public void CompleteScope()
  {
  }

  public void Dispose()
  {
  }
}