using Lib.Net.Http.WebPush;
using Lib.Net.Http.WebPush.Authentication;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BroFixe.Infrastructure.PushNotifications;

public class PushNotificationService : IPushNotificationService
{
    private readonly IPushSubscriptionsService _pushSubscriptionsService;
    private readonly PushServiceClient _pushClient;

    public PushNotificationService(IPushSubscriptionsService pushSubscriptionsService, PushServiceClient pushClient,
        IOptions<PushNotificationsOptions> options)
    {
        _pushSubscriptionsService = pushSubscriptionsService;
        _pushClient = pushClient;
        _pushClient.DefaultAuthentication = new VapidAuthentication(
            options.Value.PublicKey,
            options.Value.PrivateKey);
    }

    public async Task SendToAllSubscribers(string title, string body, string? icon = null)
    {
        var notification = CreateNotificationObject(title, body, icon);
        var notificationJson = JsonConvert.SerializeObject(notification);

        var subscriptions = await _pushSubscriptionsService.GetAll();
        foreach (var subscription in subscriptions)
            await _pushClient.RequestPushMessageDeliveryAsync(subscription, new PushMessage(notificationJson));
    }

    private static object CreateNotificationObject(string title, string body, string? icon)
    {
        var notification = new
        {
            notification = new
            {
                title = title,
                body = body,
                icon = icon
            }
        };
        return notification;
    }
}