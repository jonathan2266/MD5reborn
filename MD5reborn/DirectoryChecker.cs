using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD5reborn.logger;

namespace MD5reborn
{
    public class DirectoryChecker
    {
        private string dir;
        private string unfinishedTag;
        private Ilogger logger;
        public DirectoryChecker(string dir, string unfinishedTag, Ilogger logger)
        {
            this.dir = dir;
            this.unfinishedTag = unfinishedTag;
            this.logger = logger;
        }

        public void GetUnFinsished(out folderState state, out List<string> unfinished)
        {
            state = folderState.finished;
            string[] temp;
            List<string> unfList = new List<string>();
            try
            {
                temp = Directory.GetFiles(dir);

                for (int i = 0; i < temp.Length; i++)
                {
                    string temp2 = Path.GetFileName(temp[i]);

                    if (temp2.Contains(unfinishedTag))
                    {
                        state = folderState.unfinished;
                        unfList.Add(temp[i]);
                    }
                }
            }
            catch (Exception)
            {
                //log stuff
                Environment.Exit(1);
            }
            unfinished = unfList;
        }
    }
}
