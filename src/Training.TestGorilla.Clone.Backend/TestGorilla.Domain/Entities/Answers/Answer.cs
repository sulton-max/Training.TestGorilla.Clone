using TestGorilla.Domain.Commons;

namespace TestGorilla.Domain.Entities.Answers;
public class Answer : Auditable, IEntity
{
    public Guid QuestionId { get; set; }
    public string? AnswerText { get; set; }
    public bool IsCorrect { get; set; }

    public Answer()
    {
    }

    public Answer(Guid questionId, string? answerText, bool isCorrect)
    {
        QuestionId = questionId;
        AnswerText = answerText;
        IsCorrect = isCorrect;
    }
}
