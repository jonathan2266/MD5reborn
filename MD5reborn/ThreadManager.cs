using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD5reborn.logger;
using MD5reborn.format;
using MD5reborn.dataSaver;
using MD5reborn.DataChecker;
using System.Threading;
using MD5reborn.hash;
using System.IO;

namespace MD5reborn
{
    public class ThreadManager
    {
        private string echo = "Threadmanager created";
        private Ilogger logger;
        private IFormat format;
        private IDataChecker dChecker;
        private string dir;
        private string fileUnFinishedTag;
        private string finishedFilePath;
        private List<string> unfinishedList;
        private Thread[] workers;
        private IDataSaver[] saver;
        private int currentFileNr;
        private string currentWord;
        private bool isProgramRunning;
        private bool[] isDone;
        private int nrOfGroupedHashes;
        private folderState state;

        public ThreadManager(Ilogger logger, IFormat format, IDataChecker dChecker, string dir, string fileUnFinishedTag) //state.none
        {
            logger.log(echo); //new start
            this.logger = logger;
            this.format = format;
            this.dir = dir;
            this.fileUnFinishedTag = fileUnFinishedTag;
            this.dChecker = dChecker;

            //has to be done for everyone
            init(folderState.none);
            currentFileNr = 0;
            currentWord = "";

        }
        public ThreadManager(Ilogger logger, IFormat format, IDataChecker dChecker, string dir, string fileUnFinishedTag, string finishedFilePath) //folderState.finished
        {
            logger.log(echo); //start from last
            this.logger = logger;
            this.format = format;
            this.dir = dir;
            this.fileUnFinishedTag = fileUnFinishedTag;
            this.finishedFilePath = finishedFilePath;
            this.dChecker = dChecker;

            init(folderState.finished);
            int ignore;
            dChecker.GetLastWordOfFileInfo(finishedFilePath, out ignore, out currentWord);
            currentFileNr = Convert.ToInt32(Path.GetFileNameWithoutExtension(finishedFilePath));

        }

        public ThreadManager(Ilogger logger, IFormat format, IDataChecker dChecker, string dir, string fileUnFinishedTag, List<string> unfinishedList) //folderState.unfinished
        {
            logger.log(echo); //finish of last
            this.logger = logger;
            this.format = format;
            this.dir = dir;
            this.fileUnFinishedTag = fileUnFinishedTag;
            this.unfinishedList = unfinishedList;
            this.dChecker = dChecker;

            init(folderState.unfinished);

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
                        saver[i] = new DataSaverLocalHDD(logger, format, dir, currentFileNr + ".txt", fileUnFinishedTag);
                        workers[i] = new Thread(() => hashing(i, currentWord, nrOfGroupedHashes, saver[i]));
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

        private void hashing(int threadID, string startWord, int lenght, IDataSaver saver)
        {
            logger.log(DateTime.Now + "::Thread with ID: " + threadID + " started");
            IHash hash = new HashMD5();
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
