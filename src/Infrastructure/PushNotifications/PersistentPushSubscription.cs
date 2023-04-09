using BroFixe.Domain.Model;

namespace BroFixe.Infrastructure.PushNotifications;

public class PersistentPushSubscription : EntityBase
{
    public string Endpoint { get; set; } = default!;
    public string Data { get; set; } = default!;
}