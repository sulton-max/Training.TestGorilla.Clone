namespace TestGorilla.Domain.Commons;

public interface IAuditable : IEntity
{
    DateTime CreatedTime { get; set; }
    DateTime? UpdatedTime { get; set; }
}
