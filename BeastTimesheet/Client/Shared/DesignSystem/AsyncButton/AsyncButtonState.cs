namespace BeastTimesheet.DesignSystem;

public enum AsyncButtonState { Ready, Loading, Error }

public static class AsyncButtonStateExtensions
{
    public static AsyncButtonState Merge(this AsyncButtonState first, AsyncButtonState second) =>
        first is AsyncButtonState.Loading || second is AsyncButtonState.Loading
            ? AsyncButtonState.Loading
            : first is AsyncButtonState.Error || second is AsyncButtonState.Error
            ? AsyncButtonState.Error
            : AsyncButtonState.Ready;
}