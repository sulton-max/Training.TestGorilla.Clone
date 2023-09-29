using TestGorilla.Domain.Commons;
using TestGorilla.Domain.Entities.Answers;

namespace TestGorilla.Domain.Entities.Users;

public class UserAnswers : Auditable
{
    public Guid UserId { get; set; }
    public Guid AssessmentId { get; set; }
    public ICollection<Answer>? Answer { get; set; }
}