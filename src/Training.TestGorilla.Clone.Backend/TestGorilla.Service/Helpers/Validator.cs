using System.Text.RegularExpressions;

namespace TestGorilla.Service.Helpers;

public class Validator
{
    private const string TitleValidatorRegex = @"^.{10,50}$";
    private const string NameValidatorRegex = @"^[A-Za-z ]{2,30}$";
    private const string DescriptionValidatorRegex = @"^.{100,500}$";
    private const string EmailAddressValidatorRegex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
    private const string PasswordValidatorRegex = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";

    public static bool IsValidName(string name) =>
                    !string.IsNullOrEmpty(name) && Regex.IsMatch(name, NameValidatorRegex);
    
    public static bool IsValidEmail(string emailAddress) =>
                    !string.IsNullOrEmpty(emailAddress) && Regex.IsMatch(emailAddress, EmailAddressValidatorRegex);

    public static bool IsValidPassword(string password) =>
                    !string.IsNullOrEmpty(password) && Regex.IsMatch(password, PasswordValidatorRegex);
    
    public static bool IsValidTitle(string title) => 
                    !string.IsNullOrEmpty(title) && Regex.IsMatch(title, TitleValidatorRegex);

    public static bool IsValidDescription(string description) =>
                    !string.IsNullOrEmpty(description) && Regex.IsMatch(description, DescriptionValidatorRegex);
}