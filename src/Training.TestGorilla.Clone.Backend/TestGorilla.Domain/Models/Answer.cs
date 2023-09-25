namespace TestGorilla.Domain.Models;

public class Answer : Auditable, IAnswer
{
    public long QuestionId { get; set; }
    public bool IsCorrect { get; set; }
    public string AnswerText { get; set; }
}