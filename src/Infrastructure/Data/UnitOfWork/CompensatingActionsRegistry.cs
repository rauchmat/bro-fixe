using Microsoft.Extensions.Logging;

namespace BroFixe.Infrastructure.Data.UnitOfWork;

class CompensatingActionsRegistry : ICompensatingActionsRegistry
{
  private readonly ILogger<CompensatingActionsRegistry> _logger;
  readonly List<Func<Task>> _actions = new();

  public CompensatingActionsRegistry(ILogger<CompensatingActionsRegistry> logger)
  {
    _logger = logger;
  }

  public void RegisterAction(Func<Task> action)
  {
    _actions.Add(action);
  }

  public async Task ExecuteActions()
  {
    foreach (var action in _actions)
    {
      try
      {
        await action();
      }
      catch (Exception e)
      {
        _logger.LogError(e, "Compensating action failed");
      }
    }
  }
}