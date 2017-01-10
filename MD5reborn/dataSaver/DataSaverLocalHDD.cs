using System;
using System.IO;
using MD5reborn.logger;
using MD5reborn.format;
using System.Threading;

namespace MD5reborn.dataSaver
{
    public class DataSaverLocalHDD : DataSaver
    {
        private string echo = "DateSaverLocalHDD created";
        private string unfinishedTag;
        private string directory;
        private StreamWriter writer;
        private int flushTimer;
        private string filename;
        private int currentFlushCount = 0;
        public DataSaverLocalHDD(Ilogger logger,IFormat format, string directory, string filename, string unfinishedTag, int flushTimer) : base(logger, format)
        {
            this.logger.log(echo);
            this.directory = directory;
            this.filename = filename;
            this.unfinishedTag = unfinishedTag;
            this.flushTimer = flushTimer;
            configWriter();
        }

        public override void PushData(string text, string hash)
        {
            try
            {
                writer.WriteLineAsync(format.ParseToFormat(text, hash));
                if (currentFlushCount >= flushTimer)
                {
                    writer.FlushAsync();
                    currentFlushCount = 0;
                }
            }
            catch (Exception e)
            {
                logger.log(e.Data.ToString());
                logger.stopLogging();
                Thread.Sleep(1000);
                Environment.Exit(1);
            }
            currentFlushCount++;

        }
        private void configWriter()
        {
            try
            {
                writer = File.AppendText(directory + unfinishedTag + "/" + filename);
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
            writer.Flush();
            writer.Close();
            try
            {
                File.Move(directory + unfinishedTag + "/" + filename, directory + filename);
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
