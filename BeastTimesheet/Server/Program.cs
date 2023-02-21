using Microsoft.EntityFrameworkCore;
using BeastTimesheet.Shared.Model;
using static BeastTimesheet.Server.Config;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var connStr = builder.Environment.IsDevelopment() ? LOCAL_CONNECTION_STRING : DOCKER_CONNECTION_STRING;

builder.Services.AddNpgsql<BeastTimesheetContext>(connStr);

builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();

app.Use(async (context, next) =>
{
    var storedAuthKey = app.Configuration.GetValue<string>("Auth:Key");
    var givenAuthKey = context.Request.Headers["Key"];

    if (context.Request.Path.StartsWithSegments("/api") && givenAuthKey != storedAuthKey)
    {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsync("Wrong auth key.");
        return;
    }

    await next.Invoke();
});

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BeastTimesheetContext>();

    var sessions = new List<Session>
    {
        new Session
        {
            Description = "Dev activity",
            Date = new DateOnly(2022, 2, 3),
            StartTime = new TimeOnly(8, 0),
            StopTime = new TimeOnly(17, 0),
            BreaksTime = new TimeSpan(1, 0, 0),
        },
        new Session
        {
            Description = "Deploy stuff",
            Date = new DateOnly(2022, 2, 4),
            StartTime = new TimeOnly(8, 0),
            StopTime = new TimeOnly(18, 15),
            BreaksTime = new TimeSpan(1, 30, 0),
        }
    };

    var bill = new Bill
    {
        ExpirationDate = DateOnly.FromDateTime(DateTime.Now + TimeSpan.FromDays(30))
    };

    var timesheets = new List<Timesheet>
    {
        new Timesheet
        {
            Name = "2022-04 April",
            State = TimesheetState.Open,
            Bill = bill,
            Sessions = sessions,
        }
    };

    var project = new Project
    {
        Name = "Test project",
        HourlyFee = 25,
        Timesheets = timesheets
    };

    db.Database.Migrate();
    db.Projects!.ExecuteDelete();
    db.Projects!.Add(project);
    db.SaveChanges();
}

app.Run();
