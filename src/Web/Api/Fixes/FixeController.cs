using System.Net;
using BroFixe.Infrastructure.Data;
using BroFixe.Web.Infrastructure.OpenApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BroFixe.Web.Api.Fixes;

[UiApi]
[Route("api/fixes")]
public class FixeController : ApiController
{
    private readonly BroFixeContext _context;

    public FixeController(BroFixeContext context)
    {
        _context = context;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<FixeModel>), (int) HttpStatusCode.OK)]
    public async Task<IActionResult> GetPastFixes()
    {
        var bros = await _context.Fixes.OrderByDescending(f => f.Start).ToListAsync();

        return Ok(bros.Select(FixeMapper.ToModel));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(FixeModel), (int) HttpStatusCode.OK)]
    public async Task<IActionResult> GetFixe(Guid id)
    {
        var fixe = await _context.Fixes.SingleOrDefaultAsync(f => f.Id == id);
        if (fixe == null)
            return NotFound();

        return Ok(FixeMapper.ToModel(fixe));
    }
}