namespace TestGorilla.Data.Data
{
    public interface IDataContext 
    { 
        ValueTask SaveChangesAsync();
    }
}