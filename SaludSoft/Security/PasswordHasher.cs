using System;
using System.Linq;
using System.Security.Cryptography;

namespace SaludSoft.Security
{
    public static class PasswordHasher
    {
        // Retorna Base64 con: [v=1][iter(4)][salt(16)][hash(32)]
        public static string Hash(string password, int iterations = 100_000)
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
                // Fwk antiguos (usa HMACSHA1 por defecto)
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
                    hash = pbkdf2.GetBytes(32);
            }

            var result = new byte[1 + 4 + salt.Length + hash.Length];
            result[0] = 0x01;
            BitConverter.GetBytes(iterations).CopyTo(result, 1);
            Buffer.BlockCopy(salt, 0, result, 1 + 4, salt.Length);
            Buffer.BlockCopy(hash, 0, result, 1 + 4 + salt.Length, hash.Length);
            return Convert.ToBase64String(result);
        }

        // Para login futuro: comparar password ingresada vs hash guardado
        public static bool Verify(string password, string storedBase64)
        {
            if (string.IsNullOrEmpty(storedBase64)) return false;
            var data = Convert.FromBase64String(storedBase64);
            if (data.Length < 1 + 4 + 16 + 32) return false;

            int iterations = BitConverter.ToInt32(data, 1);

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
            return calc.SequenceEqual(storedHash);
        }
    }
}
