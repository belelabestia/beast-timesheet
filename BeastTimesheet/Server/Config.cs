namespace BeastTimesheet.Server;

public static class Config
{
    public const string LOCAL_CONNECTION_STRING = @"Host=localhost:5001;Username=postgres;Password=db_password";
    public const string DOCKER_CONNECTION_STRING = @"Host=db:5432;Username=postgres;Password=db_password";
}