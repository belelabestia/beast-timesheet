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
    db.Database.Migrate();
}

app.Run();
