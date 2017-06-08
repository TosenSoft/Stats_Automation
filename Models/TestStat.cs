using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stats_TestAutomation.Models
{
    public class TestStat
    {
        public ObjectId _id { get; set; }
        public string TestName { get; set; }
        public Dictionary<string,int> Esiti { get; set; }
        public Browser[] Browsers { get; set; }

        public class Browser
        {
            public string BrowserName { get; set; }
            public int Total { get; set; }
            public int Success { get; set; }
            public int Fails { get; set; }
            public int Dataseterror { get; set; }
            public int Timeout { get; set; }
        }
    }
}
