using Autofac;
using BroFixe.Infrastructure.Data;
using JetBrains.Annotations;
using Lib.Net.Http.WebPush;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BroFixe.Infrastructure.PushNotifications;

[UsedImplicitly]
public class PushNotificationsModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<BroFixePushSubscriptionsService>().AsImplementedInterfaces();
        builder.RegisterType<PushNotificationService>().AsImplementedInterfaces();
    }
}