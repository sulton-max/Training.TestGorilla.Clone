using TestGorilla.Domain.Commons;
using TestGorilla.Domain.Enums;

namespace TestGorilla.Domain.Entities;

public class Test : Auditable
{
    public string Title { get; set; }
    public string Description { get; set; }
    public QuestionLevel QuestionLevel { get; set; }
    public TimeSpan Duration { get; set; }

    public Test(string title, string description, QuestionLevel questionLevel, TimeSpan duration)
    {
        Title = title;
        Description = description;
        QuestionLevel = questionLevel;
        Duration = duration;
    }

    public override string ToString()
    {
        return $"Title : {Title}, Description : {Description}, Question Level : {QuestionLevel}, Duration : {Duration}";
    }
}