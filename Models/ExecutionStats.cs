using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stats_TestAutomation.Models
{
    public class ExecutionStats
    {
        public int Success { get; set; }
        public int Fails { get; set; }
        public int Dataseterror { get; set; }
        public int Timeout { get; set; }

        public ExecutionStats(int succ, int fail, int dataset, int timeout)
        {
            Success = succ;
            Fails = fail;
            Dataseterror = dataset;
            Timeout = timeout;
        }
    }
}
