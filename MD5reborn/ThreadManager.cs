using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD5reborn.logger;
using MD5reborn.format;

namespace MD5reborn
{
    public class ThreadManager
    {
        private string echo = "Threadmanager created";
        private Ilogger logger;
        private IFormat format;
        private string dir;
        private string fileUnFinishedTag;
        private string finishedFilePath;
        private List<string> unfinishedList;

        public ThreadManager(Ilogger logger, IFormat format, string dir, string fileUnFinishedTag)
        {
            logger.log(echo);
            this.logger = logger;
            this.format = format;
            this.dir = dir;
            this.fileUnFinishedTag = fileUnFinishedTag;
        }
        public ThreadManager(Ilogger logger, IFormat format, string dir, string fileUnFinishedTag, string finishedFilePath)
        {
            logger.log(echo);
            this.logger = logger;
            this.format = format;
            this.dir = dir;
            this.fileUnFinishedTag = fileUnFinishedTag;
            this.finishedFilePath = finishedFilePath;
        }
        public ThreadManager(Ilogger logger, IFormat format, string dir, string fileUnFinishedTag, List<string> unfinishedList)
        {
            logger.log(echo);
            this.logger = logger;
            this.format = format;
            this.dir = dir;
            this.fileUnFinishedTag = fileUnFinishedTag;
            this.unfinishedList = unfinishedList;
        }
    }
}
