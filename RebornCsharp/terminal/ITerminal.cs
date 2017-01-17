using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD5reborn.terminal
{
    public interface ITerminal
    {
        void Write();
        string Read();
    }
}
