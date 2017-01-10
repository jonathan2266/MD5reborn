using System;
using System.IO;
using MD5reborn.logger;
using System.Threading;

namespace MD5reborn.dataSaver
{
    public class DataSaverLocalHDD : DataSaver
    {
        private string echo = "DataSaverLocalHDD created";
        private string unfinishedTag;
        private string directory;
        private StreamWriter writer;
        private string filename;
        public DataSaverLocalHDD(Ilogger logger, string directory, string filename, string unfinishedTag) : base(logger)
        {
            this.logger.log(echo);
            this.directory = directory;
            this.filename = filename;
            this.unfinishedTag = unfinishedTag;
            configWriter();
        }

        public override void PushData(string text, string hash)
        {
            try
            {
                writer.Write(text + Environment.NewLine + hash + Environment.NewLine);
            }
            catch (Exception e)
            {
                logger.log("DataSaverLocal PushData FileName:" + filename + " " + e.Data.ToString());
                logger.stopLogging();
                Thread.Sleep(1000);
                Environment.Exit(1);
            }

        }
        private void configWriter()
        {
            try
            {
                writer = File.AppendText(directory + unfinishedTag + filename);
            }
            catch (Exception e)
            {
                logger.log(e.Data.ToString());
                logger.stopLogging();
                Thread.Sleep(1000);
                Environment.Exit(1);
            }
        }

        public override void Finish()
        {
            writer.Close();
            try
            {
                File.Move(directory + unfinishedTag + filename, directory + filename);
            }
            catch (Exception e)
            {
                logger.log(e.Data.ToString());
                logger.stopLogging();
                Thread.Sleep(1000);
                Environment.Exit(1);
            }
        }
    }
}
