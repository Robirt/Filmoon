using System.Security.Cryptography;
using System.Text;

namespace Filmoon.WebAPI.Generators;

public static class PasswordGenerator
{
    public static byte[] GenerateSalt()
    {
        byte[] salt = new byte[16];

        RandomNumberGenerator.Create().GetBytes(salt);

        return salt;
    }

    public static string GenerateHash(string password, byte[] salt)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

        byte[] combinedBytes = new byte[salt.Length + passwordBytes.Length];

        Array.Copy(salt, 0, combinedBytes, 0, salt.Length);
        Array.Copy(passwordBytes, 0, combinedBytes, salt.Length, passwordBytes.Length);

        return Convert.ToBase64String(SHA256.HashData(combinedBytes));
    }
}
