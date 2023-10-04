using System.Text.RegularExpressions;
using TestGorilla.Domain.Constans;

namespace TestGorilla.Service.Helpers;

public class ValidationService
{
    /// <summary>
    /// Regex validation for exam, test and question
    /// </summary>
    private const string TitleValidationRegex = @"";
    private const string DescriptionValidationRegex = @"";
    /// <summary>
    /// Regex for user information
    /// </summary>
    private const string NameValidationRegex = @"";
    private const string EmailValidationRegex = @"";
    private const string PasswordValidationRegex = @"";
    private const string PhoneNumberValidationRegex = @"";

    public bool IsValidTitle(string text) =>
                    !string.IsNullOrEmpty(text) && Regex.IsMatch(text, TitleValidationRegex);

    public bool IsValidName(string name) =>
                    !string.IsNullOrEmpty(name) && Regex.IsMatch(name, NameValidationRegex);

    public bool IsValidEmailAddress(string email) =>
                    !string.IsNullOrWhiteSpace(email) && Regex.IsMatch(email, EmailValidationRegex);

    public bool IsValidPassword(string password) =>
                    !string.IsNullOrWhiteSpace(password) && Regex.IsMatch(password, PasswordValidationRegex);


    public bool IsValidDescription(string description) =>
                    !string.IsNullOrEmpty(description) && Regex.IsMatch(description, DescriptionValidationRegex);
    
    public bool IsValidPhoneNumber(string phoneNumber) => 
                    !string.IsNullOrWhiteSpace(phoneNumber) && Regex.IsMatch(phoneNumber, PhoneNumberValidationRegex);
}