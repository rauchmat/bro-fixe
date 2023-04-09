namespace BroFixe.Infrastructure.PushNotifications;

public interface IPushNotificationService
{
    Task SendToAllSubscribers(string title, string body, string? icon = null);
}