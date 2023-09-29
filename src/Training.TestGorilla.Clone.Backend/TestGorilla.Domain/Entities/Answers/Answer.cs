using TestGorilla.Domain.Commons;

namespace TestGorilla.Domain.Entities.Answers;
public class Answer : Auditable
{
    public Guid QuestionId { get; set; }
    public bool IsCorrect { get; set; }
}
