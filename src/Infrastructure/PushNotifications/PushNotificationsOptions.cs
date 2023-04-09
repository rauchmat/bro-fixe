namespace BroFixe.Infrastructure.PushNotifications;

public class PushNotificationsOptions
{
    public const string SectionName = "PushNotifications";
    
    public string PublicKey { get; set; } = default!;

    public string PrivateKey { get; set; } = default!;
}