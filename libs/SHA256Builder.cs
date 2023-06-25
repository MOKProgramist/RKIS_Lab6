using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace RKIS_Lab6.libs
{
    internal class SHA256Builder
    {
        public static string ConvertToHash(string text)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] bytes = Encoding.ASCII.GetBytes(text);
            byte[] hash = sha256.ComputeHash(bytes);

            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in hash)
                stringBuilder.Append(b.ToString("X2"));
            return stringBuilder.ToString();
        }
    }
}
