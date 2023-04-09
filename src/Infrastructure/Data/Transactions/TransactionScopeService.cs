using System.Transactions;
using Autofac;
using BroFixe.Infrastructure.Utils;
using Microsoft.Extensions.Logging;

namespace BroFixe.Infrastructure.Data.Transactions;

public class TransactionScopeService : ITransactionScopeService
{
  private readonly ILifetimeScope _lifetimeScope;
  private readonly ILogger<TransactionScopeService> _logger;
  private TransactionScope? _transactionScope;
  private Transaction? _transaction;

  public TransactionScopeService(ILifetimeScope lifetimeScope, ILogger<TransactionScopeService> logger)
  {
    _lifetimeScope = lifetimeScope;
    _logger = logger;
  }

  public Transaction? EnterScope()
  {
    // try to prevent Hangfire to open a transaction scope on the root level
    if (_lifetimeScope.IsRoot())
    {
      _logger.LogDebug("Skipping creation of transaction scope for root lifetime scope.");
      return null;
    }

    if (_transactionScope != null)
      throw new InvalidOperationException("Transaction scope has already been entered.");

    (_transactionScope, _transaction) = TransactionScopeFactory.Create(TransactionScopeOption.RequiresNew);
    
    _logger.LogDebug("Created transaction {TransactionId}", _transaction.TransactionInformation.LocalIdentifier);

    return _transaction;
  }

  public void CompleteScope()
  {
    if (_lifetimeScope.IsRoot())
    {
      _logger.LogDebug("Skipping completion of transaction scope for root lifetime scope.");
      return;
    }

    if (_transactionScope == null)
      throw new InvalidOperationException("Transaction scope has not been entered.");

    _logger.LogDebug("Completing transaction {TransactionId}", _transaction!.TransactionInformation.LocalIdentifier);
    _transactionScope.Complete();
  }

  public void Dispose()
  {
    if (_transactionScope != null)
    {
      _logger.LogDebug("Disposing transaction {TransactionId}", _transaction?.TransactionInformation.LocalIdentifier);
      _transactionScope?.Dispose();

      _transaction = null;
      _transactionScope = null;
    }
  }
}