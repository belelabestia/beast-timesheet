using Microsoft.AspNetCore.Mvc;
using BeastTimesheet.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace BeastTimesheet.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TimesheetController : ControllerBase
{
    private readonly BeastTimesheetContext _context;

    public TimesheetController(BeastTimesheetContext context)
    {
        _context = context;
    }

    [HttpGet("{id:int}")]
    public Timesheet? GetTimesheet(int id)
    {
        return _context.Timesheets!.Include(t => t.Sessions).Include(t => t.Project).Include(t => t.Bill).SingleOrDefault(t => t.Id == id);
    }

    [HttpPost]
    public Timesheet CreateTimesheet(Timesheet timesheet)
    {
        _context.Timesheets!.Add(timesheet);
        _context.SaveChanges();

        return timesheet;
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateTimesheet(int id, Timesheet timesheet)
    {
        if (!_context.Timesheets!.Any(t => t.Id == id))
        {
            return NotFound();
        }

        _context.Timesheets!.Update(timesheet);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTimesheet(int id)
    {
        if (!_context.Timesheets!.Any(t => t.Id == id))
        {
            return NotFound();
        }

        _context.Timesheets!.Remove(new Timesheet { Id = id });
        await _context.SaveChangesAsync();

        return Ok();
    }
}
