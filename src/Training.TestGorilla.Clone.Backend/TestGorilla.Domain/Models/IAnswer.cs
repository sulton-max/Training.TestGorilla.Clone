namespace TestGorilla.Domain.Models;

public interface IAnswer
{
    public long QuestionId { get; set; }
    public bool IsCorrect {get; set; }
}