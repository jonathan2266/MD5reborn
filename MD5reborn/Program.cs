using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD5reborn.logger;

namespace MD5reborn
{
    class Program
    {
        static void Main(string[] args)
        {
            string directory = args[0];

            Logger logger = new FileLogger();

            string fileUnfinishedTag = "unf";
            DirectoryChecker dirCheck = new DirectoryChecker(directory, fileUnfinishedTag, logger);

            //startAguments dir
            //make logger writes down basic info in a txt file like cores/os id etc

            //checklatestmake hash

            //depending on outcome -> fire up and finish files then fire up threadmanager

            //else fire up threadmanager and hash new files

            //fire up diffrent thread for console commands

            //fire up extra thread for displaying data
        }
    }
}
