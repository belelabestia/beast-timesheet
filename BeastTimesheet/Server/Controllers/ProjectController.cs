using Microsoft.AspNetCore.Mvc;
using BeastTimesheet.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace BeastTimesheet.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly BeastTimesheetContext _context;

    public ProjectController(BeastTimesheetContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Project> GetProjects()
    {
        return _context.Projects!;
    }

    [HttpGet("{id:int}")]
    public Project? GetProject(int id)
    {
        return _context.Projects!.Include(project => project.Timesheets).SingleOrDefault(p => p.Id == id);
    }

    [HttpPost]
    public Project CreateProject(Project project)
    {
        _context.Projects!.Add(project);
        _context.SaveChanges();

        return project;
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateProject(int id, Project project)
    {
        if (!_context.Projects!.Any(p => p.Id == id))
        {
            return NotFound();
        }

        _context.Projects!.Update(project);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        if (!_context.Projects!.Any(p => p.Id == id))
        {
            return NotFound();
        }

        _context.Projects!.Remove(new Project { Id = id });
        await _context.SaveChangesAsync();

        return Ok();
    }
}
