using TestGorilla.Domain.Commons;
using TestGorilla.Domain.Enums;

namespace TestGorilla.Domain.Entities;

public class Test : Auditable
{
    public string Title { get; set; }

    public string Description { get; set; }

    public QuestionLevel QuestionLevel { get; set; }

    public int Duration { get; set; }

   /* public Test(Guid id,string title, string description, QuestionLevel questionLevel, DateTime createdTime, DateTime updatedTime, TimeSpan duration)
    {
        Id = id;    
        Title = title;
        Description = description;
        QuestionLevel = questionLevel;
        CreatedTime = createdTime;
        UpdatedTime = default(DateTime);
        Duration = duration;
    }*/

    public override string ToString()
    {
        return $"Title : {Title}, Description : {Description}, Question Level : {QuestionLevel}, Duration : {Duration}";
    }
}