namespace TestGorilla.Domain.Commons
{
    public class SoftDeletedEntity : Auditable, ISoftDeletedEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}