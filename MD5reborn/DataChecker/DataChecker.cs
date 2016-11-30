using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD5reborn.logger;

namespace MD5reborn.DataChecker
{
    public abstract class DataChecker : IDataChecker
    {
        protected Ilogger logger;
        public DataChecker(Ilogger logger)
        {
            this.logger = logger;
        }
        public abstract void GetStatus(out folderState state, out List<string> files);
    }
}
