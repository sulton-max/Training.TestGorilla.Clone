using TestGorilla.Domain.Commons;

namespace TestGorilla.Domain.Models
{
    public class Result : Auditable, IEntity
    {
        public Guid UserId { get; set; }
        public Guid TestId { get; set; }
        public Guid ExamId { get; set; }
        public Guid CategoryId { get; set; }
        public decimal TestResult { get; set; }
        public decimal ExamResult { get; set;}
        public bool IsDelete { get; set; }
        public Result()
        {
            
        }
    }
}
