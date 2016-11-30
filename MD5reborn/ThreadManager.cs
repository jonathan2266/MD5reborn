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
        private Ilogger logger;
        private string dir;
        private string programTag;
        private string fileUnFinishedTag;

        public ThreadManager(Ilogger logger, IFormat format, string dir, string programTag, string fileUnFinishedTag)
        {
            this.logger = logger;
            this.dir = dir;
            this.programTag = programTag;
            this.fileUnFinishedTag = fileUnFinishedTag;
        }
        public void FinishRemainingFiles(List<string> unfinished)
        {

        }
        public void StartFromCompleteFile()
        {

        }
    }
}
