using TestGorilla.Domain.Commons;
using TestGorilla.Domain.Enums;

namespace TestGorilla.Domain.Entities;

public class Test : Auditable
{
    public string Title { get; set; }

    public string Description { get; set; }

    public QuestionLevel QuestionLevel { get; set; }

    public int Duration { get; set; }
}