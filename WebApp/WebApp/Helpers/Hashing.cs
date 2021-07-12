using System.Security.Cryptography;
using System.Text;

namespace WebApp.Helpers
{
    public class Hashing
    {
        public static string GetSha512Hash(string plainText)
        {
            using (SHA512 hash = new SHA512Managed())
            {
                byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(plainText));

                StringBuilder builder = new StringBuilder();
                foreach (var t in bytes)
                {
                    builder.Append(t.ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}