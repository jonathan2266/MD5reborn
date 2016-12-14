using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD5reborn.logger;

namespace MD5reborn.format
{
    public class FormatSingleLine : Format
    {
        private string echo = "FormatSingleLine Created";
        public FormatSingleLine(Ilogger logger) : base(logger)
        {
            logger.log(echo);
        }

        public override string GetHash(string fileLine)
        {
            throw new NotImplementedException();
        }

        public override string GetWord(string fileLine)
        {
            throw new NotImplementedException();
        }

        public override string ParseToFormat(string text, string hash)
        {
            string formatted;

            formatted = text + Environment.NewLine + hash + Environment.NewLine; //wanne include support for mixed OS hashing

            return formatted;
        }
    }
}
