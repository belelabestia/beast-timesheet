using Microsoft.AspNetCore.Mvc;
using BeastTimesheet.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace BeastTimesheet.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SessionController : ControllerBase
{
    private readonly BeastTimesheetContext _context;

    public SessionController(BeastTimesheetContext context)
    {
        _context = context;
    }

    [HttpGet("{id:int}")]
    public Session? GetSession(int id)
    {
        return _context.Sessions!.Include(s => s.Timesheet).ThenInclude(t => t!.Project).SingleOrDefault(s => s.Id == id);
    }

    [HttpPost]
    public Session CreateSession(Session session)
    {
        _context.Sessions!.Add(session);
        _context.SaveChanges();

        return session;
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateSession(int id, Session session)
    {
        if (!_context.Sessions!.Any(s => s.Id == id))
        {
            return NotFound();
        }

        _context.Sessions!.Update(session);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteSession(int id)
    {
        if (!_context.Sessions!.Any(s => s.Id == id))
        {
            return NotFound();
        }

        _context.Sessions!.Remove(new Session { Id = id });
        await _context.SaveChangesAsync();

        return Ok();
    }
}
