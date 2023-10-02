namespace TestGorilla.Domain.Commons;

public abstract class Auditable : IEntity
{
    public Guid Id { get; set; }
    protected DateTime CreatedTime { get; init; } = DateTime.UtcNow;
    public DateTime UpdatedTime { get; set;}
    public bool IsDeleted { get; set; }
    public DateTime DeletedDate { get; set; }
}