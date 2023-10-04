using TestGorilla.Domain.Commons;
using TestGorilla.Domain.Entities.Answers;

namespace TestGorilla.Domain.Entities.Questions;

public class ShortAnswerTypeQuestion : Auditable, IQuestion
{
    public string Title { get; set ; }
    public string Description { get ; set ; }
    public TimeSpan Duration { get; set; }
    public Category Category { get ; set ; }
    public ShortAnswer Answer { get; set; }
    public ShortAnswerTypeQuestion()
    {
        
    }
    public ShortAnswerTypeQuestion(string title, string description, TimeSpan duration, Category category,ShortAnswer Shortanswer)
    {
        Answer = Shortanswer;
        Title = title;
        Description = description;
        Duration = duration;
        Category = category;
    }
}