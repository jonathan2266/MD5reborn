using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//functions
//stop app -> let it stop clean -> fire event 
// get total file size
// random display info
// get current progress

namespace MD5reborn.terminal
{
    public class TerminalLocalScreen : Terminal
    {
        public override string Read()
        {
             return Console.ReadLine();
        }

        public override void Write()
        {
            
        }
    }
}
