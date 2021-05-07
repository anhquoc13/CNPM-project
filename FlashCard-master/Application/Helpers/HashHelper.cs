using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace mvcMovie.Infrastructure
{
    public class HashHelper
    {
        public static void CreateHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                return passwordHash.SequenceEqual(hash);
            }
        }
    }
}