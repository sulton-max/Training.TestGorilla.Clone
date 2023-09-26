using TestGorilla.Domain.Commons;

namespace TestGorilla.Domain.Models;

public class Answer : Auditable, IAnswer, IEntity
{
    public Guid QuestionId { get; set; }
    public bool IsCorrect { get; set; }
    public string AnswerText { get; set; }
}