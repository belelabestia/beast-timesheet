using Microsoft.AspNetCore.Mvc;
using BeastTimesheet.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace BeastTimesheet.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BillController : ControllerBase
{
    private readonly BeastTimesheetContext _context;

    public BillController(BeastTimesheetContext context)
    {
        _context = context;
    }

    [HttpGet("{id:int}")]
    public Bill? GetBill(int id)
    {
        return _context.Bills!.Include(b => b.Timesheet).ThenInclude(t => t!.Project).SingleOrDefault(b => b.Id == id);
    }

    [HttpPost]
    public Bill CreateBill(Bill bill)
    {
        _context.Bills!.Add(bill);
        _context.SaveChanges();

        return bill;
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateBill(int id, Bill bill)
    {
        if (!_context.Bills!.Any(b => b.Id == id))
        {
            return NotFound();
        }

        _context.Bills!.Update(bill);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBill(int id)
    {
        if (!_context.Bills!.Any(b => b.Id == id))
        {
            return NotFound();
        }

        _context.Bills!.Remove(new Bill { Id = id });
        await _context.SaveChangesAsync();

        return Ok();
    }
}
