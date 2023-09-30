using TestGorilla.Domain.Commons;

namespace TestGorilla.Domain.Entities.Answers;
public class ShortAnswer : Auditable
{
    public Guid QuestionId { get; set; }
    public string AnswerText { get; set; }
    public bool IsCorrect { get; set; }
    public bool IsChecked { get; set; }

    public ShortAnswer() { }

    public ShortAnswer(Guid questionId, string answerText)
    {
        QuestionId = questionId;
        AnswerText = answerText;
        IsCorrect = false;
        IsChecked = false;
    }
}
