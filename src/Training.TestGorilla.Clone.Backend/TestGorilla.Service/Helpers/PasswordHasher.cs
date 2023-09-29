namespace TestGorilla.Service.Helpers;

public static class PasswordHasher
{
    public static string Hash(this string password) =>
                    BCrypt.Net.BCrypt.HashPassword(password);
        
    public static bool Verify(this string password, string hashedPassword) =>
                    BCrypt.Net.BCrypt.Verify(password, hashedPassword);
}