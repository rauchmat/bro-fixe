using System.Net;
using BroFixe.Infrastructure.Data;
using BroFixe.Web.Api.Fixes;
using BroFixe.Web.Infrastructure.OpenApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BroFixe.Web.Api.PushNotifications;

[UiApi]
[Route("api/push-notifications")]
public class PushNotificationsController : ApiController
{
    private readonly BroFixeContext _context;

    public PushNotificationsController(BroFixeContext context)
    {
        _context = context;
    }

    [HttpGet("public-key")]
    [ProducesResponseType(typeof(IEnumerable<FixeModel>), (int) HttpStatusCode.OK)]
    public async Task<IActionResult> GetPastFixes()
    {
        var bros = await _context.Fixes
            .Include(f => f.Organizer)
            .OrderByDescending(f => f.Start)
            .ToListAsync();

        return Ok(bros.Select(FixeMapper.ToModel));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(FixeModel), (int) HttpStatusCode.OK)]
    public async Task<IActionResult> GetFixe(Guid id)
    {
        var fixe = await _context.Fixes
            .Include(f => f.Organizer)
            .SingleOrDefaultAsync(f => f.Id == id);
        
        if (fixe == null)
            return NotFound();

        return Ok(FixeMapper.ToModel(fixe));
    }
}