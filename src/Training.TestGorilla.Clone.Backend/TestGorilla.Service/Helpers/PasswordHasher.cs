namespace TestGorilla.Service.Helpers;

<<<<<<< HEAD
public class PasswordHasher
{
    
=======
public class PasswordHasher: IPasswordHasherService
{
    public string Hash(string password) =>
                    BCrypt.Net.BCrypt.HashPassword(password);
    
    public bool Verify(string password, string hashedPassword) => 
                    BCrypt.Net.BCrypt.Verify(password, hashedPassword);
>>>>>>> bfa2f0906d5c70b03208bc389a3a53826ace22df
}