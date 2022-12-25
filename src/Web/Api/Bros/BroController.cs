using System.Net;
using BroFixe.Infrastructure.Data;
using BroFixe.Web.Infrastructure.OpenApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BroFixe.Web.Api.Bros;

[UiApi]
[Route("api/bros")]
public class BroController : ApiController
{
    private readonly BroFixeContext _context;

    public BroController(BroFixeContext context)
    {
        _context = context;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<BroModel>), (int) HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllBros()
    {
        var bros = await _context.Bros.OrderBy(b => b.Nickname).ToListAsync();

        return Ok(bros.Select(BroMapper.ToModel));
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(BroModel), (int) HttpStatusCode.OK)]
    public async Task<IActionResult> GetBro(Guid id)
    {
        var bro = await _context.Bros.SingleOrDefaultAsync(f => f.Id == id);
        if (bro == null)
            return NotFound();

        return Ok(BroMapper.ToModel(bro));
    }
}