namespace BroFixe.Infrastructure.Data.UnitOfWork;

public interface ICompensatingActionsRegistry
{
  void RegisterAction(Func<Task> action);
  Task ExecuteActions();
}