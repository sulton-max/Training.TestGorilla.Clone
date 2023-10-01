using TestGorilla.Domain.Commons;

namespace TestGorilla.Domain.Entities.Questions;

public class ShortAnswerTypeQuestion : Auditable, IQuestion
{
    public string Title { get; set ; }
    public string Description { get ; set ; }
    public TimeSpan Duration { get; set; }
    public Category Category { get ; set ; }

    public ShortAnswerTypeQuestion(string title, string description, TimeSpan duration, Category category)
    {
        Title = title;
        Description = description;
        Duration = duration;
        Category = category;
    }
}