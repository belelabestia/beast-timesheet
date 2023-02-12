using Microsoft.EntityFrameworkCore;
using static Config;

var builder = WebApplication.CreateBuilder(args);
var connStr = builder.Environment.IsDevelopment() ? LOCAL_CONNECTION_STRING : DOCKER_CONNECTION_STRING;

builder.Services.AddNpgsql<BloggingContext>(connStr);
builder.Services.AddControllersWithViews();
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
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BloggingContext>();
    db.Database.Migrate();

    db.Blogs!.ExecuteDelete();

    db.Blogs!.Add(new Blog { BlogId = 1, Url = "https://test.url" });
    db.SaveChanges();
}

app.Run();
