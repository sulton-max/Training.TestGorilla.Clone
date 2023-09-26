namespace TestGorilla.Domain.Models;

public interface IAnswer
{
    public Guid QuestionId { get; set; }
    public bool IsCorrect {get; set; }
}