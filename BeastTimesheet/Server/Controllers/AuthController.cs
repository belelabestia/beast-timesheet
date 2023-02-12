using Microsoft.AspNetCore.Mvc;

namespace BeastTimesheet.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpGet]
    public IActionResult Verify() => Ok("Key is valid.");
}