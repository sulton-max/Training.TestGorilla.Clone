using TestGorilla.Domain.Commons;
using TestGorilla.Domain.Entities.Answers;

namespace TestGorilla.Domain.Entities.Questions;

public class MultipleChoiceQuestion : Auditable, IQuestion
{
    public string Title { get; set ; }
    public string Description { get ; set; }
    public TimeSpan Duration { get; set; }
    public ICollection<Answer> Answers { get; set ; }
    public Category Category { get; set; }
    public MultipleChoiceQuestion(string title, string description, TimeSpan duration, ICollection<Answer> answers, Category category)
    {
        Title = title;
        Description = description;
        Duration = duration;
        Answers = answers;
        Category = category;
    }
}