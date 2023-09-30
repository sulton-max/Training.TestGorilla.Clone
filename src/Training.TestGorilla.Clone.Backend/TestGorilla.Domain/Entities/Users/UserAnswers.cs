using TestGorilla.Domain.Commons;
using TestGorilla.Domain.Entities.Answers;
using TestGorilla.Domain.Entities.Questions;

namespace TestGorilla.Domain.Entities.Users;

public class UserAnswers : Auditable
{
    public Guid UserId { get; set; }
    public User? User { get; set; }
    
    public Guid AssessmentId { get; set; }
    public Assessment? Assessment { get; set; }
    
    public Guid QuestionsId { get; set; }
    public IQuestion? Question { get; set; }
    
    public Guid? AnswerId { get; set; }
    public Answer? Answer { get; set; }
}