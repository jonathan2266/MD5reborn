using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD5reborn.logger;
using MD5reborn.format;

namespace MD5reborn.dataSaver
{
    public abstract class DataSaver : IDataSaver, IDisposable
    {
        protected Ilogger logger;
        protected IFormat format;
        public DataSaver(Ilogger logger, IFormat format)
        {
            this.format = format;
            this.logger = logger;
        }

        public abstract void Dispose();
        public abstract void PushData(string text, string hash);
    }
}
