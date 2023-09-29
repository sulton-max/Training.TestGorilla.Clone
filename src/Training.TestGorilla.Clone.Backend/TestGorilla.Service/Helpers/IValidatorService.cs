namespace TestGorilla.Service.Helpers;

public interface IValidatorService
{
    bool IsValidName(string name);

    bool IsValidEmail(string emailAddress);

    bool IsValidPhoneNumber(string phoneNumber);

    bool IsValidPassword(string password);

    bool IsValidTitle(string title);

    bool IsValidDescription(string description);
}