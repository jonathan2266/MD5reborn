using System;
using System.Collections.Generic;
using MD5reborn.logger;
using MD5reborn.DataChecker;
using MD5reborn.terminal;
using MD5reborn.hash;
using System.IO;

namespace MD5reborn
{
    class Program
    {
        static ThreadManager tManager;
        static void Main(string[] args)
        {
            //args
            //Dir
            List<string> directory = new List<string>();
            int count = 0;
            for (int i = 0; i < args.Length; i++)
            {
                if (Directory.Exists(args[i]))
                {
                    directory.Add(args[i]);
                    count++;
                }
                else
                {
                    break;
                }
            }
            
            #region hash
            Hasher hash = new HashMD5();
            try
            {
                HashType hashType = (HashType)Enum.Parse(typeof(HashType), args[count], true);
                if (hashType == HashType.MD5)
                {
                    hash = new HashMD5();
                }
                if (hashType == HashType.SHA256)
                {
                    hash = new HashSHA256();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error parsing second command line argument Fill in one of these: " + HashType.MD5.ToString() + " " + HashType.SHA256 + " "  + e);
                Console.ReadLine();
                Environment.Exit(1);
            }
            #endregion

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

            if (state == folderState.finished)
            {
                tManager = new ThreadManager(logger, dataChecker, directory, fileUnfinishedTag, files[0], hash);
            }
            else //state.none
            {
                tManager = new ThreadManager(logger, dataChecker, directory, fileUnfinishedTag, hash);
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
