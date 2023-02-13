namespace BeastTimesheet.Shared.Model;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public Decimal HourlyFee { get; set; }
    IEnumerable<Timesheet>? Timesheets { get; set; }
}

public enum TimesheetState { Open, Closed }

public class Timesheet
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public TimesheetState State { get; set; }
    public Project? Project { get; set; }
}

public class Session
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly StopTime { get; set; }
    public TimeSpan BreaksTime { get; set; }
    public TimeSpan GrossTime => StopTime - StartTime;
    public TimeSpan NetTime => GrossTime - BreaksTime;
    public Decimal SessionFee => Convert.ToDecimal(NetTime.TotalHours) * Timesheet!.Project!.HourlyFee;
    public Timesheet? Timesheet { get; set; }
}

public enum BillState { Emitted, Payed, Expired }

public class Bill
{
    public int Id { get; set; }
    public DateTime ExpirationDate { get; set; }
    public bool Expired => DateTime.Now > ExpirationDate;
    public bool Payed { get; set; }
}

/**************************************/

public class Blog
{
    public int BlogId { get; set; }
    public string? Url { get; set; }

    public List<Post> Posts { get; } = new();
}

public class Post
{
    public int PostId { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }

    public int BlogId { get; set; }
    public Blog? Blog { get; set; }
}