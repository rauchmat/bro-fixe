using System.Net;
using BroFixe.Infrastructure.PushNotifications;
using BroFixe.Web.Infrastructure.OpenApi;
using Lib.Net.Http.WebPush;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BroFixe.Web.Api.PushNotifications;

[UiApi]
[Route("api/push-subscriptions")]
public class PushSubscriptionsController : ApiController
{
    private readonly IPushSubscriptionsService _pushSubscriptionsService;
    private readonly string _publicKey;

    public PushSubscriptionsController(IPushSubscriptionsService pushSubscriptionsService, IOptions<PushNotificationsOptions> options)
    {
        _pushSubscriptionsService = pushSubscriptionsService;
        _publicKey = options.Value.PublicKey;
    }

    [HttpGet("public-key")]
    [ProducesResponseType(typeof(string), (int) HttpStatusCode.OK)]
    public IActionResult GetPublicKey()
    {
        return Ok(_publicKey);
    }
    
    [HttpPost]
    [ProducesResponseType((int) HttpStatusCode.Created)]
    public async Task CreateSubscription([FromBody] PushSubscription subscription)
    {
        await _pushSubscriptionsService.Insert(subscription);
    }

    [HttpDelete("{endpoint}")]
    [ProducesResponseType((int) HttpStatusCode.OK)]
    public async Task DeleteSubscription(string endpoint)
    {
       await _pushSubscriptionsService.Delete(WebUtility.UrlDecode(endpoint));
    }
}