namespace TestGorilla.Domain.Commons;

public abstract class Auditable : IAuditable
{
    public Guid Id { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
}