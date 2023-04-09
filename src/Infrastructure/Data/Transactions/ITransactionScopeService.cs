using System.Transactions;

namespace BroFixe.Infrastructure.Data.Transactions;

public interface ITransactionScopeService : IDisposable
{
  Transaction? EnterScope();
  void CompleteScope();
}