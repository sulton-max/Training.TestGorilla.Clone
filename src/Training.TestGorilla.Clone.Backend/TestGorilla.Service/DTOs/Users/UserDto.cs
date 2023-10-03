using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGorilla.Service.DTOs.Users
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public UserDto(string firstname, string lastName, string email, string phoneNumber)
        {
            Id = Guid.NewGuid();
            FirstName = firstname;
            LastName = lastName;
            EmailAddress = email;
            PhoneNumber = phoneNumber;
        }
    }
}
