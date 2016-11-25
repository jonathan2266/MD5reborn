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

        public List<string> GetUnFinsished()
        {
            List<string> unfinished = new List<string>();
            string[] temp;
            try
            {
                temp = Directory.GetFiles(dir);
            }
            catch (Exception)
            {
                //log stuff
                Environment.Exit(1);
            }
            for (int i = 0; i < temp.Length; i++)
            {
                string temp2 = Path.GetFileName(temp[i]);
                
                if (temp[i].Contains(unfinishedTag))
                {
                    unfinished.Add(temp[i]);
                }
            }

            return unfinished;
        }
    }
}
