using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD5reborn.logger
{
    public interface Ilogger
    {
        void log(string text);
        void stopLogging();
    }
}
