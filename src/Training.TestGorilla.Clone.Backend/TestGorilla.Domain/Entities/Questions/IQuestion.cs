using TestGorilla.Domain.Commons;

namespace TestGorilla.Domain.Entities.Questions;

public interface IQuestion 
{
    public string Title { get; set; }
    public string Description { get; set; }
    public TimeSpan Duration { get; set; }
    public Category Category { get; set; }
}