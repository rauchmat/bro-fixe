using Autofac;

namespace BroFixe.Infrastructure.Data.UnitOfWork
{
  public class UnitOfWorkWrapper : IDisposable
  {
    private readonly IUnitOfWork _unitOfWork;
    
    public ILifetimeScope LifetimeScope { get; }

    public UnitOfWorkWrapper(IUnitOfWork unitOfWork, ILifetimeScope lifetimeScope)
    {
      _unitOfWork = unitOfWork;
      LifetimeScope = lifetimeScope;
    }

    public TService Resolve<TService>() where TService : notnull
    {
      return LifetimeScope.Resolve<TService>();
    }

    public async Task Complete()
    {
      await _unitOfWork.Complete();
    }

    public void Dispose ()
    {
      LifetimeScope.Dispose();
    }
  }
}