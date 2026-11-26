using System;
using System.Security.Cryptography;
using TaskMaster.Application.BaseInfo.Users;

namespace TaskMaster.Persistence.Hash
{
    public class HashPassword : IHashPassword
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iteration = 100000;
        public string Hash(string password)
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            using (var pkdf2 = new Rfc2898DeriveBytes(
                password,
                salt,
                Iteration,
                HashAlgorithmName.SHA256
                ))
            {
                byte[] hash = pkdf2.GetBytes(HashSize);
                return $"PBKDF2$SHA256${Iteration}${Convert.ToBase64String(hash)}";
            }
        }
    }
}
