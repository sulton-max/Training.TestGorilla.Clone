using TestGorilla.Domain.Enums;

namespace TestGorilla.Domain.Models;
public class Test
{
    public string Title { get; set; }
    public string Description { get; set; }
    public QuestionLevel QuestionLevel { get; set; }
    public DateTime Time { get; set; }
}
