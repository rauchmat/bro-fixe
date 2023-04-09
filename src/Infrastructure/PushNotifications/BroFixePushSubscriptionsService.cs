using BroFixe.Infrastructure.Data;
using Lib.Net.Http.WebPush;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BroFixe.Infrastructure.PushNotifications;

public class BroFixePushSubscriptionsService : IPushSubscriptionsService
{
    private readonly BroFixeContext _broFixeContext;

    public BroFixePushSubscriptionsService(BroFixeContext broFixeContext)
    {
        _broFixeContext = broFixeContext;
    }

    public async Task<IEnumerable<PushSubscription>> GetAll()
    {
        return (await _broFixeContext.PushSubscriptions.ToListAsync()).Select(MapToPushSubscription);
    }

    private PushSubscription MapToPushSubscription(PersistentPushSubscription persistentPushSubscription) =>
        JsonConvert.DeserializeObject<PushSubscription>(persistentPushSubscription.Data);

    public async Task Insert(PushSubscription subscription)
    {
        var persistentPushSubscription = MapToPersistentPushSubscription(subscription);
        await _broFixeContext.AddAsync(persistentPushSubscription);
    }

    private PersistentPushSubscription MapToPersistentPushSubscription(PushSubscription pushSubscription) =>
        new()
        {
            Endpoint = pushSubscription.Endpoint,
            Data = JsonConvert.SerializeObject(pushSubscription)
        };

    public async Task Delete(string endpoint)
    {
        var subscriptionsToRemove = await _broFixeContext.PushSubscriptions
            .Where(s => s.Endpoint == endpoint)
            .ToListAsync();
        _broFixeContext.RemoveRange(subscriptionsToRemove);
    }
}