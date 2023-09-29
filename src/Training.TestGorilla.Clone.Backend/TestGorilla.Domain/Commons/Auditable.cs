namespace TestGorilla.Domain.Commons;

public abstract class Auditable
{
    public Guid Id {get;}
    public DateTime CreatedTime { get;}
    public DateTime UpdatedTime { get;}
}