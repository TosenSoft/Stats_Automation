using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Xml;
using Stats_TestAutomation.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Stats_TestAutomation.Controllers
{
	public class StatsController : Controller
	{
		#region private fields

		//private static List<ExecutionStats> data = new List<ExecutionStats>();
		//private static readonly List<string> Browsers = new List<string> { "chrome", "chromium", "edge", "firefox", "ie", "safari" };
		//private const string Testxmlpath = @"C:\Users\Matthew\Desktop\Statistiche_TestCase.xml";
		//private const string Browserxmlpath = @"C:\Users\Matthew\Desktop\TestCase_ByBrowsers.xml";
		private static List<string> tc = new List<string> { "Dettaglio", "Login", "Logout", "LoginAgenzia", "LogoutAgenzia", "Preventivo", "PreventivoAgenzia" };
		private static List<string> esiti = new List<string> { "Success", "Fails", "Dataseterror", "Timeout" };
		private static List<TestStat> tests = new List<TestStat>();
		#endregion

		// GET: /Stats/
		public ActionResult Index()
		{
			MongoClient mongoC = new MongoClient("mongodb://localhost");
			IMongoDatabase db = mongoC.GetDatabase("tests");
			var col1 = db.GetCollection<TestStat>("testautomation");
			foreach (string testcase in tc)
			{
				if (tests.Count < tc.Count)
				{
					var tcr = col1
						.Find(i => i.TestName == testcase)
						.SortBy(i => i.TestName)
						.ToListAsync()
						.Result;
					tests.Add(tcr.First());
				}
			}

			//XmlTextReader xmlR = new XmlTextReader(Testxmlpath);
			//XmlDocument xmlBody = new XmlDocument();
			//xmlBody.Load(xmlR);
			//xmlR.Close();
			//XmlNodeList xmlChildren = xmlBody.SelectNodes("/testcases/*");
			//foreach (XmlNode node in xmlChildren)
			//{
			//    if(test.Count < 7)
			//        test.Add(new TestStat(Int32.Parse(node.ChildNodes[1].InnerText), Int32.Parse(node.ChildNodes[2].InnerText), Int32.Parse(node.ChildNodes[3].InnerText), Int32.Parse(node.ChildNodes[4].InnerText)));
			//}
			return View(tests);
		}

		public ActionResult Index2()
		{
			return Json("/stats/Index");
		}

		[HttpPost]
		public ActionResult Browser()
		{
			//QUERY SU MONGO PER OTTENERE DATI SU BROWSER E TEST
			//foreach (string br in Browsers)
			//{
			//    data.Add(new ExecutionStats());
			//}
			//XmlTextReader xmlR = new XmlTextReader(Browserxmlpath);
			//XmlDocument xmlBody = new XmlDocument();
			//xmlBody.Load(xmlR);
			//xmlR.Close();
			//int i = 0;
			//foreach (string browser in Browsers)
			//{
			//    data[i].ExecutionsList = new List<int>();
			//    XmlNodeList xmlChildren = xmlBody.SelectNodes("/browsers/*[@id='" + browser + "']");
			//    foreach (XmlNode xmlNode in xmlChildren)
			//    {
			//        foreach (XmlNode xmlChild in xmlNode.ChildNodes)
			//        {
			//            if (data[i].ExecutionsList.Count < 7)
			//                data[i].ExecutionsList.Add(Int32.Parse(xmlChild.ChildNodes[0].InnerText));
			//        }
			//    }
			//    i++;
			//}

			return Json("/Stats/BrowserStat");
		}

		[HttpPost]
		public ActionResult SetChart(string testName)
		{
			if (testName != "preventivo")
			{
				return Json(new
				{
					value = "LALALALAL"
				});
			} else {
				return Json(new 
				{
					value = "ALALH"
				});
			}
		}

		public ActionResult BrowserStat()
		{
			return View(tests);
		}
	}
}
