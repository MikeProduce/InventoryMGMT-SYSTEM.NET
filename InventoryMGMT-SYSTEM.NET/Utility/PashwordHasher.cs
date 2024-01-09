using BCrypt.Net;


namespace InventoryMGMT_SYSTEM.NET.Utility.PasswordHasher;

public class PasswordHasher
{
    public static string HashPassword(string password)
    {
        string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
        return BCrypt.Net.BCrypt.HashPassword(password, salt);
    }
}
