using BroFixe.Infrastructure.Data.Transactions;

namespace BroFixe.Infrastructure.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly BroFixeContext _broFixeContext;
    private readonly ITransactionScopeService _transactionScopeService;
    private readonly ICompensatingActionsRegistry _actionRegistry;

    public UnitOfWork(BroFixeContext broFixeContext, ITransactionScopeService transactionScopeService,
        ICompensatingActionsRegistry actionRegistry)
    {
        _broFixeContext = broFixeContext;
        _transactionScopeService = transactionScopeService;
        _actionRegistry = actionRegistry;
    }

    public async Task Complete()
    {
        try
        {
            await _broFixeContext.SaveChangesAsync();
            _transactionScopeService.CompleteScope();
        }
        catch (Exception)
        {
            await _actionRegistry.ExecuteActions();
            throw;
        }
    }
}