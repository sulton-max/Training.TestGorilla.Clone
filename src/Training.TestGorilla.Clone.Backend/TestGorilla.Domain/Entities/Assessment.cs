using TestGorilla.Domain.Commons;
using TestGorilla.Domain.Entities.Users;

namespace TestGorilla.Domain.Entities;

/// <summary>
/// Assessment is as a exam class
/// </summary>
public class Assessment : Auditable, IEntity
{
    public ICollection<User> Users { get; set; }

    public ICollection<Test> Tests { get; set; }
    
    public TimeSpan Duration { get; set; }
    
    public bool IsActive { get; set; }
    
    public bool IsDeleted { get; set; }

    public Assessment()
    {
    }
    public Assessment(ICollection<User> users, ICollection<Test> tests, TimeSpan duration)
    {
        Users = users;
        Tests = tests;
        Duration = duration;
        IsActive = false;
        IsDeleted = false;
    }
}