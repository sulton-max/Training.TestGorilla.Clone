using TestGorilla.Domain.Commons;
using TestGorilla.Domain.Enums;

namespace TestGorilla.Domain.Models;
  
public class User : Auditable, IMembership
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
}