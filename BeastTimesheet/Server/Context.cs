using Microsoft.EntityFrameworkCore;
using BeastTimesheet.Shared.Model;

public class BeastTimesheetContext : DbContext
{
    public DbSet<Project>? Projects { get; set; }
    public DbSet<Timesheet>? Timesheets { get; set; }
    public DbSet<Session>? Sessions { get; set; }
    public DbSet<Bill>? Bills { get; set; }

    public BeastTimesheetContext(DbContextOptions<BeastTimesheetContext> options) : base(options) { }
}