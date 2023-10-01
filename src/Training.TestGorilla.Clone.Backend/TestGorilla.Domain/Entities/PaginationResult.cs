  namespace TestGorilla.Domain.Entities;

public class PaginationResult<T>
{
    public IEnumerable<T> Items { get; set; }
    public int TotalItems { get; set; }
    public int PageToken { get; set; }
    public int PageSize { get; set; }
}