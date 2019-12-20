using System.Text;
using System.Security.Cryptography;

namespace Kopiowanie
{
    class Hash
    {
        public static byte[] GetHash(string text)
        {
            HashAlgorithm algorithm = MD5.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(text));
        }

        public static string GetHashString(string text)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(text))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}
