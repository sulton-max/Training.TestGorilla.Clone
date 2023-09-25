namespace TestGorilla.Domain.Models;
public class Exam : Auditable
{
    public string Title { get; set; }
    public string Description { get; set; }
    public TimeSpan Duration { get; set; }
    public long CreatorId { get; set; }
    public long ExaminatorId { get; set; }
    public List<Test> Tests { get; set; }
    public List<User> Candidates { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }

    public Exam()
    {

    }
}
