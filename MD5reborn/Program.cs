using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD5reborn.logger;
using MD5reborn.dataSaver;
using MD5reborn.DataChecker;
using MD5reborn.terminal;
using System.Threading;

namespace MD5reborn
{
    class Program
    {
        static ThreadManager tManager;
        static void Main(string[] args)
        {
            //arg
            string directory = args[0];

            //initial vars
            string fileUnfinishedTag = "unf";
            string logFileName = "MD5rebornLogs";

            //initial classes
            Logger logger = new FileLogger(logFileName);
            logSystemInfo(logger);

            Terminal terminal = new TerminalLocalScreen();

            //dirCheck
            DataChecker.DataChecker dataChecker = new DataCheckerLocalHDD(logger, directory, fileUnfinishedTag);

            folderState state;
            List<string> files = new List<string>();

            dataChecker.GetStatus(out state, out files);

            if (state == folderState.unfinished)
            {
                tManager = new ThreadManager(logger, dataChecker, directory, fileUnfinishedTag, files);
            }
            else if (state == folderState.finished)
            {
                tManager = new ThreadManager(logger, dataChecker, directory, fileUnfinishedTag, files[0]);
            }
            else //state.none
            {
                tManager = new ThreadManager(logger, dataChecker, directory, fileUnfinishedTag);
            }

            //startAguments dir
            //make logger writes down basic info in a txt file like cores/os id etc

            //checklatestmake hash

            //depending on outcome -> fire up and finish files then fire up threadmanager

            //else fire up threadmanager and hash new files

            //fire up diffrent thread for console commands

            //fire up extra thread for displaying data
            tManager.Start();
        }

        private static void logSystemInfo(Ilogger logger)
        {
            logger.log("OS: " + Environment.OSVersion);
            logger.log("Cores: " + Environment.ProcessorCount);
        }
        private static void StartCalc()
        {
            tManager.Start();
        }
    }
}
