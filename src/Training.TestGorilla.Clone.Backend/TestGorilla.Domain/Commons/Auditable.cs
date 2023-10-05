namespace TestGorilla.Domain.Commons;

public abstract class Auditable : IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedTime { get; set;}
    public bool IsDeleted { get; set; }
    public DateTime? DeletedDate { get; set; }
}