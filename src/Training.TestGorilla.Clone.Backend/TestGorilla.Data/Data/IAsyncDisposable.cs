namespace TestGorilla.Data.Data
{
    public interface IAsyncDisposable
    {
        ValueTask DisposeAsync();
    }
}