using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD5reborn.logger;
using System.IO;
using System.Threading;

namespace MD5reborn.DataChecker
{
    public class DataCheckerLocalHDD : DataChecker
    {
        private string echo = "DataCheckerLocalHDD created";
        private string unfinishedTag;
        private string directory;
        public DataCheckerLocalHDD(Ilogger logger, string directory, string unfinishedTag) : base(logger)
        {
            logger.log(echo);
            this.directory = directory;
            this.unfinishedTag = unfinishedTag;
        }
        public override void GetStatus(out folderState state, out List<string> files)
        {
            state = folderState.finished;
            string[] temp = new string[1];
            List<string> unfList = new List<string>();
            try
            {
                temp = Directory.GetFiles(directory);

                //test none state
                if (temp == null) //check if null then
                {
                    state = folderState.none;
                }
                //test for unfinished state
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
            catch (Exception e)
            {
                logger.log(e.Data.ToString());
                logger.stopLogging();
                Thread.Sleep(1000);
                Environment.Exit(1);
            }

            if (state == folderState.finished)
            {
                unfList = getLastestFile(temp);
            }

            files = unfList;
        }
        private List<string> getLastestFile(string[] temp)
        {
            List<string> ret = new List<string>();
            string[] local = new string[temp.Length];
            int biggest = 0;

            for (int i = 0; i < temp.Length; i++)
            {
                local[i] = Path.GetFileName(temp[i]);
                local[i] = local[i].Remove(local.Length - 5, local.Length - 1);

                try
                {
                    if (Convert.ToInt32(local[biggest]) < Convert.ToInt32(local[i]))
                    {
                        biggest = i;
                    }
                }
                catch (Exception e)
                {
                    logger.log(e.Data.ToString());
                    logger.stopLogging();
                    Thread.Sleep(1000);
                    Environment.Exit(1);
                }
            }

            ret.Add(temp[biggest]);

            return ret;
        }
    }
}
