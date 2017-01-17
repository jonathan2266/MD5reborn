using System.Security.Cryptography;
using System.Text;

namespace MD5reborn.hash
{
    public class HashMD5 : Hasher
    {
        public override string Hash(string text)
        {
            byte[] tmpscrc = ASCIIEncoding.ASCII.GetBytes(text);
            byte[] hash = new MD5CryptoServiceProvider().ComputeHash(tmpscrc);
            return formatSolution(hash);
        }
    }
}
