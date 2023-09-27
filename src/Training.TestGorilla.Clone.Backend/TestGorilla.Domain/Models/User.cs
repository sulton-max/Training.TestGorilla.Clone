using FileBaseContext.Abstractions.Models.Entity;
using TestGorilla.Domain.Commons;
using TestGorilla.Domain.Enums;

namespace TestGorilla.Domain.Models;

public class User : SoftDeletedEntity, IFileSetEntity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public UserRole Role { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }

    public User(Guid id, string firstName, string lastName, string emailAddress, UserRole role, DateTime dateOfBirth, string phoneNumber)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        Role = role;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        CreatedTime = DateTime.UtcNow;
        DeletedDate = default(DateTime);
        IsDeleted = false;
    }

    public override string ToString()
    {
        return $"Id: {Id}, First name: {FirstName}, Last name: {LastName}, Email address: {EmailAddress}, Phone number: {PhoneNumber}";
    }
}