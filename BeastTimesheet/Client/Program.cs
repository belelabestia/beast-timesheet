using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BeastTimesheet.Client;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<Auth>();

await builder.Build().RunAsync();

public class Auth
{
    string? _key;
    public string? Key
    {
        get => _key;
        set
        {
            _key = value;
            OnChange?.Invoke();
        }
    }

    public event Action? OnChange;
}