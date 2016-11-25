using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD5reborn.logger;
using MD5reborn.format;

namespace MD5reborn
{
    class Program
    {
        static void Main(string[] args)
        {
            //arg
            string directory = args[0];

            //initial vars
            string fileUnfinishedTag = "unf";

            //initial classes
            Logger logger = new FileLogger();
            Format format = new FormatSingleLine();

            //dirCheck
            DirectoryChecker dirCheck = new DirectoryChecker(directory, fileUnfinishedTag, logger);

            folderState state;
            List<string> unfinished = new List<string>();

            dirCheck.GetUnFinsished(out state, out unfinished);

            if (state == folderState.unfinished)
            {

            }
            else
            {

            }

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
