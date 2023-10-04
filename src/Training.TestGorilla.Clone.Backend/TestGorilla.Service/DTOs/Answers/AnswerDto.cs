namespace TestGorilla.Service.DTOs.Answers;

public class AnswerDto
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public string? AnswerText { get; set; }
    public bool IsCorrect { get; set; }

    public AnswerDto()
    {
    }

    public AnswerDto(Guid questionId, string? answerText, bool isCorrect)
    {
        Id = Guid.NewGuid();
        QuestionId = questionId;
        AnswerText = answerText;
        IsCorrect = isCorrect;
    }
}
