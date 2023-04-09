namespace BroFixe.Infrastructure.Data.UnitOfWork;

public interface IUnitOfWork
{
  Task Complete();
}