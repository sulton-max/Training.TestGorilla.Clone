namespace TestGorilla.Domain.Entities.Answers;
public class Answer
{
    public Guid Id {  get; set; }
    public Guid QuestionId { get; set; }
    public bool IsCorrect { get; set; }
}
