using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD5reborn.logger;
using MD5reborn.format;

namespace MD5reborn.format
{
    public abstract class Format : IFormat
    {
        protected Ilogger logger;
        public Format(Ilogger logger)
        {
            this.logger = logger;
        }

        public abstract string GetHash(string fileLine);
        public abstract string GetWord(string fileLine);
        public abstract string ParseToFormat(string text, string hash);
    }
}
