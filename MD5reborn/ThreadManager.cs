using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD5reborn.logger;
using MD5reborn.dataSaver;
using MD5reborn.DataChecker;
using System.Threading;
using MD5reborn.hash;
using System.IO;

namespace MD5reborn
{
    public class ThreadManager
    {
        private string echo = "Threadmanager: ";
        private Ilogger logger;
        private IDataChecker dChecker;
        private string dir;
        private string fileUnFinishedTag;
        private string finishedFilePath;
        private Thread[] workers;
        private IDataSaver[] saver;
        private int currentFileNr;
        private string currentWord;
        private bool isProgramRunning;
        private bool[] isDone;
        private int nrOfGroupedHashes;
        private folderState state;
        private IHash hash;

        public ThreadManager(Ilogger logger, IDataChecker dChecker, string dir, string fileUnFinishedTag, IHash hash) //state.none
        {
            logger.log(echo + "created"); //new start
            this.logger = logger;
            this.dir = dir;
            this.fileUnFinishedTag = fileUnFinishedTag;
            this.dChecker = dChecker;
            this.hash = hash;

            //has to be done for everyone
            init(folderState.none);
            currentFileNr = 0;
            currentWord = "";

        }
        public ThreadManager(Ilogger logger, IDataChecker dChecker, string dir, string fileUnFinishedTag, string finishedFilePath, IHash hash) //folderState.finished
        {
            logger.log(echo + "created"); //start from last
            this.logger = logger;
            this.dir = dir;
            this.fileUnFinishedTag = fileUnFinishedTag;
            this.finishedFilePath = finishedFilePath;
            this.dChecker = dChecker;
            this.hash = hash;

            init(folderState.finished);
            int ignore;
            dChecker.GetLastWordOfFileInfo(finishedFilePath, out ignore, out currentWord);
            try
            {
                currentFileNr = Convert.ToInt32(Path.GetFileNameWithoutExtension(finishedFilePath));
            }
            catch (Exception e)
            {
                logger.log(echo + e);
                logger.stopLogging();
                Environment.Exit(1);
            }

        }
        public void Start()
        {
            manage();
        }
        private void init(folderState state)
        {
            isProgramRunning = true;
            nrOfGroupedHashes = 6000000;

            this.state = state;
            isDone = new bool[Environment.ProcessorCount]; 
            workers = new Thread[Environment.ProcessorCount];

            saver = new IDataSaver[Environment.ProcessorCount];
            if (state == folderState.none || state == folderState.finished)
            {
                for (int i = 0; i < Environment.ProcessorCount; i++)
                {
                    isDone[i] = true;
                }
            }
        }
        private void manage()
        {
            while (isProgramRunning)
            {
                for (int i = 0; i < workers.Length; i++)
                {
                    if (isDone[i] == true)
                    {
                        //new job and start
                        currentFileNr++;
                        saver[i] = new DataSaverLocalHDD(logger, dir, currentFileNr + ".txt", fileUnFinishedTag);
                        workers[i] = new Thread(() => hashing(i, currentWord, nrOfGroupedHashes, saver[i], hash));
                        workers[i].Start();
                        isDone[i] = false;

                        logger.log(DateTime.Now + "::Finding next job");
                        WordGenerator w = new WordGenerator(currentWord);
                        //create new currentword with Wordjumper
                        for (int j = 0; j < nrOfGroupedHashes; j++) //temp cuz wordjumper no ready
                        {
                            w.Next();
                        }
                        currentWord = w.GetCurrentWord();
                        logger.log(DateTime.Now + "::Next job found");
                    }
                }
                Thread.Sleep(1);
            }
        }

        private void hashing(int threadID, string startWord, int lenght, IDataSaver saver, IHash hash)
        {
            logger.log(DateTime.Now + "::Thread with ID: " + threadID + " started");
            WordGenerator wGen = new WordGenerator(startWord);

            for (int i = 0; i < lenght; i++)
            {
                wGen.Next();
                saver.PushData(wGen.GetCurrentWord(), hash.Hash(wGen.GetCurrentWord()));
            }

            saver.Finish();
            isDone[threadID] = true;
            logger.log(DateTime.Now + "::Thread with ID: " + threadID + " completed");
        }
    }
}
