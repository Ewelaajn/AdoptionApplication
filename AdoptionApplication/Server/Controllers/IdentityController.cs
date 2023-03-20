using Microsoft.AspNetCore.Mvc;

namespace AdoptionApplication.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IdentityController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> GetIpAddress()
    {
        var clientIpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
        return Ok(clientIpAddress);
    }
}