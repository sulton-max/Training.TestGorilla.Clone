namespace TestGorilla.Domain.Commons
{
    public interface ISoftDeletedEntity : IAuditable
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedDate { get; set; }
    }
}
