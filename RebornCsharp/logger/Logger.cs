using System.Collections.Concurrent;

namespace MD5reborn.logger
{
    abstract public class Logger : Ilogger
    {
        protected bool isFunctional;
        protected ConcurrentQueue<string> writeBuffer = new ConcurrentQueue<string>();

        public abstract void log(string text);

        public abstract void stopLogging();
    }
}
