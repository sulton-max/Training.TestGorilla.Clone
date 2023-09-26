namespace TestGorilla.Domain.Models.Questions.InterfeysQuestion;
public interface IQuestion
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Answer Answer { get; set; }
    public DateTime Duration { get; set; }
}

