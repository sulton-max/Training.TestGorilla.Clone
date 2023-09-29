using System.Text.RegularExpressions;
using TestGorilla.Domain.Constans;

namespace TestGorilla.Service.Helpers;

public static class Validator 
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
    private const string EmailValidationRegex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{8,32}$";
    private const string PasswordValidationRegex = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$";
    private const string PhoneNumberValidationRegex = @"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]{7,20}$";

    public static bool IsValidTitle(string text) =>
                    !string.IsNullOrEmpty(text) && Regex.IsMatch(text, TitleValidationRegex);

    public static bool IsValidName(string name) =>
                    !string.IsNullOrEmpty(name) && Regex.IsMatch(name, NameValidationRegex);

    public static bool IsValidEmailAddress(string email) =>
                    !string.IsNullOrWhiteSpace(email) && Regex.IsMatch(email, EmailValidationRegex);

    public static bool IsValidPassword(string password) =>
                    !string.IsNullOrWhiteSpace(password) && Regex.IsMatch(password, PasswordValidationRegex);


    public static bool IsValidDescription(string description) =>
                    !string.IsNullOrEmpty(description) && Regex.IsMatch(description, DescriptionValidationRegex);
    
    public static bool IsValidPhoneNumber(string phoneNumber) => 
                    !string.IsNullOrWhiteSpace(phoneNumber) && Regex.IsMatch(phoneNumber, PhoneNumberValidationRegex);
}