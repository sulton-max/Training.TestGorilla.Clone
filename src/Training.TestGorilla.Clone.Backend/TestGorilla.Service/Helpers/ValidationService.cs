using System.Text.RegularExpressions;
using TestGorilla.Domain.Constans;

namespace TestGorilla.Service.Helpers;

public class ValidationService
{
    /// <summary>
    /// Regex validation for exam, test and question
    /// </summary>
    private const string TitleValidationRegex = @"^.{10,50}$";
    private const string DescriptionValidationRegex = @"^.{40,500}$";
    /// <summary>
    /// Regex for user information
    /// </summary>
    private const string NameValidationRegex = @"^[A-Za-z ]{3,20}$";
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


    public bool IsValidDescription(string description) =>
                    !string.IsNullOrEmpty(description) && Regex.IsMatch(description, DescriptionValidationRegex);
    
    public bool IsValidPhoneNumber(string phoneNumber) => 
                    !string.IsNullOrWhiteSpace(phoneNumber) && Regex.IsMatch(phoneNumber, PhoneNumberValidationRegex);
}