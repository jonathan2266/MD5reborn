using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD5reborn.logger;
using MD5reborn.format;
using System.IO;
using System.Threading;

namespace MD5reborn.DataChecker
{
    public class DataCheckerLocalHDD : DataChecker
    {
        private string echo = "DataCheckerLocalHDD created";
        private string unfinishedTag;
        private string directory;
        private IFormat format;
        public DataCheckerLocalHDD(Ilogger logger, IFormat format, string directory, string unfinishedTag) : base(logger)
        {
            logger.log(echo);
            this.directory = directory;
            this.unfinishedTag = unfinishedTag;
            this.format = format;
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
                if (temp.Length == 0) //check if null then
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

            if (temp.Length < 0)
            {
                ret.Add(temp[biggest]);
            }

            return ret;
        }

        public override void GetLastWordOfFileInfo(string fileDir, out int lineNumber, out string word) //add asycn option? :) //wrong need to be in formatter class
        {
            StreamReader reader;
            string read = "";
            int iterations = 0;

            try
            {
                reader = new StreamReader(fileDir);
                string temp;
                while (true)
                {
                    temp = reader.ReadLine();
                    if (temp != null)
                    {
                        read = temp;
                        iterations++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (read == "")
                {
                    throw new Exception("The file contents returned \"\"");
                }
            }
            catch (Exception e)
            {
                logger.log("fatal in DataCheckerLocalHDD " + e.Data);
                logger.stopLogging();
                Thread.Sleep(500);
                Environment.Exit(1);
            }

            word = format.GetWord(read);
            lineNumber = iterations;
            
        }
    }
}
