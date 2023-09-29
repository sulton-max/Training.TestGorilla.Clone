namespace TestGorilla.Domain.Models.Questions.InterfeysQuestion;
public interface IQuestion
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Answer Answer { get; set; }
<<<<<<< HEAD
    public TimeSpan Duration { get; set; }
=======
    public DateTime Duration { get; set; }
>>>>>>> bfa2f0906d5c70b03208bc389a3a53826ace22df
}

