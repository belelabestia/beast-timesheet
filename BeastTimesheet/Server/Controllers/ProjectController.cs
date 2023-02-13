using Microsoft.AspNetCore.Mvc;
using BeastTimesheet.Shared;
using BeastTimesheet.Shared.Model;

namespace BeastTimesheet.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly BeastTimesheetContext _context;

    public ProjectsController(ILogger<WeatherForecastController> logger, BeastTimesheetContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Project> Get()
    {
        return _context.Projects!;
    }
}
