using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MD5reborn.hash
{
    public abstract class Hasher : IHash
    {
        public abstract string Hash(string text);
        protected string formatSolution(byte[] hash)
        {
            StringBuilder output = new StringBuilder();
            string solution;
            for (int i = 0; i < hash.Length; i++)
            {
                output.Append(hash[i].ToString("X2"));
            }
            solution = Convert.ToString(output);
            return solution;
        }
    }
}
