using TestGorilla.Domain.Commons;
namespace TestGorilla.Domain.Models;

public class UserCredentials : SoftDeletedEntity
{
    public string Password { get; set; }
    public Guid UserId { get; init; }

    public UserCredentials()
    {
    }

    public UserCredentials(string password, Guid userId)
    {
        Id = Guid.NewGuid();
        Password = password;
        UserId = userId;
        CreatedTime = DateTime.UtcNow;
        IsDeleted = false;
    }

    public override string ToString()
    {
        return $"Password: {Password}\n" +
            $"UserId: {UserId}\n" +
            $"CreatedDate: {CreatedTime}\n" +
            $"UpdatedDate: {UpdatedTime}\n" +
            $"DeletedDate: {DeletedDate}\n" +
            $"IsDeleted: {IsDeleted}\n\n";
    }
}
