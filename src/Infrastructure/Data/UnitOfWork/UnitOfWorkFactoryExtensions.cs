using Autofac;
using Microsoft.Extensions.DependencyInjection;

namespace BroFixe.Infrastructure.Data.UnitOfWork
{
  public static class UnitOfWorkFactoryExtensions
  {
    public static UnitOfWorkWrapper StartUnitOfWork(this IServiceProvider serviceProvider, Action<ContainerBuilder>? registerAction = null)
    {
      var lifetimeScope = serviceProvider.GetRequiredService<ILifetimeScope>();
      return lifetimeScope.StartUnitOfWork(registerAction);
    }

    public static UnitOfWorkWrapper StartUnitOfWork(this ILifetimeScope parentLifetimeScope, Action<ContainerBuilder>? registerAction = null)
    {
      var unitOfWorkLifetimeScope = parentLifetimeScope.BeginLifetimeScope(registerAction ?? (_ => { }));
      var unitOfWork = unitOfWorkLifetimeScope.Resolve<IUnitOfWork>(); //triggers creation of connection and transaction scope

      return new UnitOfWorkWrapper(unitOfWork, unitOfWorkLifetimeScope);
    }

    public static async Task<TResult> ExecuteInUnitOfWork<TSubject, TResult>(this ILifetimeScope lifetimeScope, Func<TSubject, Task<TResult>> action)
      where TSubject : notnull
      where TResult : notnull
    {
      using var unitOfWork = lifetimeScope.StartUnitOfWork(b => b.RegisterType<TSubject>());
      var stage = unitOfWork.Resolve<TSubject>();
      var result = await action.Invoke(stage);
      await unitOfWork.Complete();
      return result;
    }

    public static async Task ExecuteInUnitOfWork<TSubject>(this ILifetimeScope lifetimeScope, Func<TSubject, Task> action)
      where TSubject : notnull
    {
      using var unitOfWork = lifetimeScope.StartUnitOfWork(b => b.RegisterType<TSubject>());
      var stage = unitOfWork.Resolve<TSubject>();
      await action.Invoke(stage);
      await unitOfWork.Complete();
    }
  }
}