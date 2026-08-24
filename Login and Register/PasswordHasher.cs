using System.Security.Cryptography;
using System.Text;

namespace Login_and_Register
{
    internal static class PasswordHasher
    {
        public static string ComputeSha256Hash(string value)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(value));
                StringBuilder hashBuilder = new StringBuilder(hashBytes.Length * 2);

                foreach (byte hashByte in hashBytes)
                {
                    hashBuilder.Append(hashByte.ToString("x2"));
                }

                return hashBuilder.ToString();
            }
        }
    }
}
