using System.Text.RegularExpressions;
using TestGorilla.Domain.Constans;

namespace TestGorilla.Service.Helpers;

public class ValidationService
{
    /// <summary>
    /// Regex validation for exam, test and question
    /// </summary>
    private const string TitleValidationRegex = @"^.{1,256}$";
    /// <summary>
    /// Regex for user information
    /// </summary>
    private const string NameValidationRegex = @"^[a-zA-Z0-9][a-zA-Z0-9.,'\-_ ]*[a-zA-Z0-9]$";
    private const string EmailValidationRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
    private const string PasswordValidationRegex = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$";
    private const string PhoneNumberValidationRegex = @"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]{7,20}$";

    public bool IsValidTitle(string text) =>
                    !string.IsNullOrEmpty(text) && Regex.IsMatch(text, TitleValidationRegex);

    public bool IsValidName(string name) =>
                    !string.IsNullOrEmpty(name) && Regex.IsMatch(name, NameValidationRegex);

    public bool IsValidEmailAddress(string email) =>
                    !string.IsNullOrWhiteSpace(email) && Regex.IsMatch(email, EmailValidationRegex);

    public bool IsValidPassword(string password) =>
                    !string.IsNullOrWhiteSpace(password) && Regex.IsMatch(password, PasswordValidationRegex);


    public bool IsValidDescription(string description)
    {
        if(description == null)
        {
            return false;
        }
        if(string.IsNullOrWhiteSpace(description))
        {
            return false;
        }
        if (string.IsNullOrEmpty(description))
        {
            return false;
        }
        return true;
    }
    
    public bool IsValidPhoneNumber(string phoneNumber) => 
                    !string.IsNullOrWhiteSpace(phoneNumber) && Regex.IsMatch(phoneNumber, PhoneNumberValidationRegex);
}