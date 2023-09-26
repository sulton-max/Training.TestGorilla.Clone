using TestGorilla.Domain.Commons;
using TestGorilla.Domain.Enums;

namespace TestGorilla.Domain.Models;
public class Test : Auditable, IEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public QuestionLevel QuestionLevel { get; set; }
    public TimeSpan Duration { get; set; }
    public Test()
    {
        
    }
}
