using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace FinCRM.ApplicationServices
{
    public static class Hasher
    {

        public static string HashPassword(string password, string saltString)
        {
            //convert saltString na saltArray
            byte[] salt = System.Text.Encoding.ASCII.GetBytes(saltString);

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }

        public static string GetSalt()
        {
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            string saltString = System.Text.Encoding.UTF8.GetString(salt);
            return saltString;
        }
    }
}