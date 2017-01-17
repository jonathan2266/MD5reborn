using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MD5reborn.hash
{
    class HashMD5_C : Hasher
    {
        [DllImport("cryptoC.dll")]
        public static extern string md5(string data);
        public override string Hash(string text)
        {
            return md5(text);
        }
    }
}
