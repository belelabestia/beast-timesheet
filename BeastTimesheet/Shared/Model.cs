namespace BeastTimesheet.Shared.Model;

public record Project
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public decimal HourlyFee { get; set; }
    public IEnumerable<Timesheet>? Timesheets { get; set; }
    public IEnumerable<Bill>? Bills { get; set; }
}

public enum TimesheetState { Open, Closed }

public record Timesheet
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public TimesheetState State { get; set; }
    public int ProjectId { get; set; }
    public Project? Project { get; set; }
    public Bill? Bill { get; set; }
    public IEnumerable<Session>? Sessions { get; set; }
}

public record Session
{
    public int Id { get; set; }
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public TimeOnly StartTime { get; set; } = new TimeOnly(9, 0);
    public TimeOnly StopTime { get; set; } = new TimeOnly(18, 0);
    public TimeOnly BreaksTime { get; set; } = new TimeOnly(1, 0);
    public string Note { get; set; } = "";
    public int TimesheetId { get; set; }
    public Timesheet? Timesheet { get; set; }
    public TimeSpan GrossTime => StopTime - StartTime;
    public TimeSpan NetTime => GrossTime - BreaksTime.ToTimeSpan();
    public decimal SessionFee => Convert.ToDecimal(NetTime.TotalHours) * Timesheet?.Project?.HourlyFee ?? 0;
}

public enum BillState { Emitted, Payed, Expired }

public record Bill
{
    public int Id { get; set; }
    public DateOnly ExpirationDate { get; set; } = DateOnly.FromDateTime(DateTime.Now + TimeSpan.FromDays(30));
    public bool Payed { get; set; }
    public int TimesheetId { get; set; }
    public Timesheet? Timesheet { get; set; }
    public Project? Project => Timesheet?.Project;
    public bool Expired => DateOnly.FromDateTime(DateTime.Now) > ExpirationDate;
    public TimeSpan TotalTime => Timesheet?.Sessions?.Select(s => s.NetTime).Aggregate(TimeSpan.Zero, (acc, next) => acc + next) ?? TimeSpan.Zero;
    public decimal TotalFee => Timesheet?.Sessions?.Select(s => s.SessionFee).Sum() ?? decimal.Zero;
}
