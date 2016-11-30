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
        private string filePath;
        private StreamWriter writer;
        private int flushTimer;
        private int currentFlushCount = 0;
        public DataSaverLocalHDD(Ilogger logger,IFormat format, string filePath, string unfinishedTag, int flushTimer) : base(logger, format)
        {
            this.logger.log(echo);
            this.flushTimer = flushTimer;
            this.filePath = filePath;
            this.unfinishedTag = unfinishedTag;
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
        public override void Dispose()
        {
            writer.Flush();
            writer.Close();
        }
        private void configWriter()
        {
            try
            {
                writer = File.AppendText(filePath);
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
