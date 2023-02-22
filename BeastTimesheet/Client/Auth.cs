namespace BeastTimesheet.Client;

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