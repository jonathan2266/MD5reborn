using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD5reborn.terminal
{
    public abstract class Terminal : ITerminal
    {
        public abstract string Read();

        public abstract void Write();
    }
}
