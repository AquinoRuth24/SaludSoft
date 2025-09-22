using System;
using System.Linq;
using System.Security.Cryptography;

namespace SaludSoft.Security
{
    public static class PasswordHasher
    {
        // [v=1][iter(4 LE)][salt(16)][hash(32)]
        public static string Hash(string password, int iterations = 150_000)
        {
            if (string.IsNullOrWhiteSpace(password)) return null;

            var salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(salt);

            byte[] hash;
            try
            {
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
                    hash = pbkdf2.GetBytes(32);
            }
            catch (MissingMethodException)
            {
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
                    hash = pbkdf2.GetBytes(32);
            }

            var result = new byte[1 + 4 + salt.Length + hash.Length];
            result[0] = 0x01; // versión
            BitConverter.GetBytes(iterations).CopyTo(result, 1); // little-endian
            Buffer.BlockCopy(salt, 0, result, 1 + 4, salt.Length);
            Buffer.BlockCopy(hash, 0, result, 1 + 4 + salt.Length, hash.Length);
            return Convert.ToBase64String(result);
        }

        public static bool Verify(string password, string storedBase64)
        {
            if (string.IsNullOrEmpty(storedBase64) || string.IsNullOrWhiteSpace(password))
                return false;

            byte[] data;
            try { data = Convert.FromBase64String(storedBase64); }
            catch { return false; }

            if (data.Length < 1 + 4 + 16 + 32)
                return false;

            byte version = data[0];
            if (version != 0x01)
                return false; // (opcional) soportar versiones futuras

            int iterations = BitConverter.ToInt32(data, 1);
            if (iterations <= 0) return false;

            var salt = new byte[16];
            Buffer.BlockCopy(data, 1 + 4, salt, 0, salt.Length);

            var storedHash = new byte[32];
            Buffer.BlockCopy(data, 1 + 4 + salt.Length, storedHash, 0, storedHash.Length);

            byte[] calc;
            try
            {
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
                    calc = pbkdf2.GetBytes(32);
            }
            catch (MissingMethodException)
            {
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
                    calc = pbkdf2.GetBytes(32);
            }

#if NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER
            return CryptographicOperations.FixedTimeEquals(calc, storedHash);
#else
            // Fallback razonable
            return calc.SequenceEqual(storedHash);
#endif
        }
    }
}
