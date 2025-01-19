using System.Security.Cryptography;
using System.Text;

namespace EKtu.Infrastructure
{
    public static class Hashing
    {
        public static string HashData(string password)
        {
            using (var create = SHA512.Create())
            {
                byte[] bytesArray = create.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < bytesArray.Length; i++)
                {
                    stringBuilder.Append(bytesArray[i].ToString("x2"));
                }
                return stringBuilder.ToString();
            }

        }
    }
}
