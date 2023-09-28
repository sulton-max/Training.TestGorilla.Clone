using System.Text.RegularExpressions;

namespace TestGorilla.Service.Helpers;

public class Validator : IValidatorService
{
    /// <summary> ///
    /// This regexs matches user data
    /// </summary>
    private const string NameValidatorRegex = @"^[A-Za-z ]{2,30}$";
    private const string EmailAddressValidatorRegex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
    private const string PhoneNumberValidatorRegex = @"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$";
    private const string PasswordValidatorRegex = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";
    
    /// <summary>
    /// Validation regex for Exams and Question
    /// </summary>
    private const string TitleValidatorRegex = @"^.{10,50}$";
    private const string DescriptionValidatorRegex = @"^.{100,500}$";
    
    public bool IsValidName(string name) =>
                    !string.IsNullOrEmpty(name) && Regex.IsMatch(name, NameValidatorRegex);
    
    public bool IsValidEmail(string emailAddress) =>
                    !string.IsNullOrEmpty(emailAddress) && Regex.IsMatch(emailAddress, EmailAddressValidatorRegex);
    
    public bool IsValidPhoneNumber(string phoneNumber) => 
                    !string.IsNullOrEmpty(phoneNumber) && Regex.IsMatch(phoneNumber, PhoneNumberValidatorRegex);
    
    public bool IsValidPassword(string password) =>
                    !string.IsNullOrEmpty(password) && Regex.IsMatch(password, PasswordValidatorRegex);
    
    public bool IsValidTitle(string title) => 
                    !string.IsNullOrEmpty(title) && Regex.IsMatch(title, TitleValidatorRegex);
    
    public bool IsValidDescription(string description) =>
                    !string.IsNullOrEmpty(description) && Regex.IsMatch(description, DescriptionValidatorRegex);
}