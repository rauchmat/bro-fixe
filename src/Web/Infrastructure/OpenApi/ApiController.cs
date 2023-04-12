using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BroFixe.Web.Infrastructure.OpenApi;

[Authorize]
[ApiController]
public class ApiController : ControllerBase
{
}