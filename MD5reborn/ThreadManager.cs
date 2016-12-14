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

namespace MD5reborn
{
    public class ThreadManager
    {
        private string echo = "Threadmanager created";
        private Ilogger logger;
        private IFormat format;
        private IDataSaver dSaver;
        private IDataChecker dChecker;
        private string dir;
        private string fileUnFinishedTag;
        private string finishedFilePath;
        private List<string> unfinishedList;
        private Thread[] workers;

        public ThreadManager(Ilogger logger, IFormat format, IDataChecker dChecker, IDataSaver dSaver, string dir, string fileUnFinishedTag)
        {
            logger.log(echo); //new start
            this.logger = logger;
            this.format = format;
            this.dir = dir;
            this.fileUnFinishedTag = fileUnFinishedTag;
            this.dSaver = dSaver;
            this.dChecker = dChecker;

            //has to be done for everyone
            init();
        }
        public ThreadManager(Ilogger logger, IFormat format, IDataChecker dChecker, IDataSaver dSaver, string dir, string fileUnFinishedTag, string finishedFilePath)
        {
            logger.log(echo); //start from last
            this.logger = logger;
            this.format = format;
            this.dir = dir;
            this.fileUnFinishedTag = fileUnFinishedTag;
            this.finishedFilePath = finishedFilePath;
            this.dChecker = dChecker;

            init();
        }

        public ThreadManager(Ilogger logger, IFormat format, IDataChecker dChecker, IDataSaver dSaver, string dir, string fileUnFinishedTag, List<string> unfinishedList)
        {
            logger.log(echo); //finish of last
            this.logger = logger;
            this.format = format;
            this.dir = dir;
            this.fileUnFinishedTag = fileUnFinishedTag;
            this.unfinishedList = unfinishedList;
            this.dChecker = dChecker;

            init();
        }
        private void init()
        {
            workers = new Thread[Environment.ProcessorCount];
        }
    }
}
