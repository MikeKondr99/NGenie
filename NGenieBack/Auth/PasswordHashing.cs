using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace NGenieBack.Auth
{
    public static class PasswordHashing
    {
        public static string HashString(string password, byte[] salt)
        {
            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashed;
        }

        public static byte[] GenSalt()
        {
            // cryptographically strong random bytes.
            return RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes
        }
    }
}
