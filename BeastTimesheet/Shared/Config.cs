using System.Text.Json;
using System.Text.Json.Serialization;

namespace BeastTimesheet.Shared;

public static class Config
{
    public static JsonSerializerOptions JSON_OPTIONS => new()
    {
        ReferenceHandler = ReferenceHandler.Preserve,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public const string VERSION = "0.3.0";
}