namespace TestGorilla.Service.Helpers;

public interface IPasswordHasherService
{
    string Hash(string password);

    bool Verify(string password, string hashedPassword);
}