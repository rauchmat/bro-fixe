using System.Net;
using BroFixe.Web.Api.Bros;
using BroFixe.Web.Infrastructure.OpenApi;
using Microsoft.AspNetCore.Mvc;

namespace BroFixe.Web.Api.Events;

[UiApi]
[Route("api/events")]
public class EventController : ApiController
{
    public EventController()
    {
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<EventModel>), (int) HttpStatusCode.OK)]
    public Task<IActionResult> GetAllEvents()
    {
        return Task.FromResult<IActionResult>(Ok(new BroModel[0]));
    }
}