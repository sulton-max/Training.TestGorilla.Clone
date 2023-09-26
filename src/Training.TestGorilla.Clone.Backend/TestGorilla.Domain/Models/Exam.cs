using TestGorilla.Domain.Commons;

namespace TestGorilla.Domain.Models;
public class Exam : Auditable, IEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public TimeSpan Duration { get; set; }
    public Guid CreatorId { get; set; }
    public Guid ExaminatorId { get; set; }
    public List<Test> Tests { get; set; }
    public List<User> Candidates { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }

    public Exam()
    {

    }
}
