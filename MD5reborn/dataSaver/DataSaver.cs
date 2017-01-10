using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD5reborn.logger;

namespace MD5reborn.dataSaver
{
    public abstract class DataSaver : IDataSaver
    {
        protected Ilogger logger;
        public DataSaver(Ilogger logger)
        {
            this.logger = logger;
        }

        public abstract void PushData(string text, string hash);
        public abstract void Finish();
    }
}
