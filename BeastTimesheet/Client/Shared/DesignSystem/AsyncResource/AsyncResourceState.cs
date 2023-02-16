namespace BeastTimesheet.DesignSystem;

public enum AsyncResourceState { Loading, Success, Error }

public static class AsyncResourceStateExtensions
{
    public static AsyncResourceState Merge(this AsyncResourceState first, AsyncResourceState second) =>
        first is AsyncResourceState.Loading || second is AsyncResourceState.Loading
            ? AsyncResourceState.Loading
            : first is AsyncResourceState.Error || second is AsyncResourceState.Error
            ? AsyncResourceState.Error
            : AsyncResourceState.Success;
}