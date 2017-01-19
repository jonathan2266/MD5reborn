using System.Security.Cryptography;
using System.Text;

namespace MD5reborn.hash
{
    public class HashSHA512 : Hasher
    {
        public override string Hash(string text)
        {
            byte[] tmpscrc = ASCIIEncoding.ASCII.GetBytes(text);
            byte[] hash = new SHA512CryptoServiceProvider().ComputeHash(tmpscrc);
            return formatSolution(hash);
        }
    }
}
