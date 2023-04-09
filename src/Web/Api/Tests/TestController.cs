using BroFixe.Infrastructure.Data;
using BroFixe.Infrastructure.PushNotifications;
using BroFixe.Web.Infrastructure.OpenApi;
using Microsoft.AspNetCore.Mvc;

namespace BroFixe.Web.Api.Tests;

[UiApi]
[Route("api/tests")]
public class TestController : ApiController
{
    private readonly IPushNotificationService _pushNotificationService;

    public TestController(IPushNotificationService pushNotificationService)
    {
        _pushNotificationService = pushNotificationService;
    }

    [HttpPost]
    public async Task<IActionResult> TestNotifications()
    {
        await _pushNotificationService.SendToAllSubscribers(
            title: "Test Benachrichtigung",
            body: "Das ist eine Testbenachrichtung von Bro Fixe App.",
            icon: "assets/icons/icon-96x96.png");
        return Ok();
    }
}