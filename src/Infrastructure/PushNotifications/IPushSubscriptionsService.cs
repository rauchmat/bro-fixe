using Lib.Net.Http.WebPush;

namespace BroFixe.Infrastructure.PushNotifications;

public interface IPushSubscriptionsService
{
    Task<IEnumerable<PushSubscription>> GetAll();
    Task Insert(PushSubscription subscription);
    Task Delete(string endpoint);
}