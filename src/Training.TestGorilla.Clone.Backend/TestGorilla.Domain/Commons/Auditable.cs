namespace TestGorilla.Domain.Commons;

public abstract class Auditable
{
    public Guid Id { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdateTime { get; set; }
}
