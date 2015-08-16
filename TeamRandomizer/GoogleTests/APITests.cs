using Microsoft.VisualStudio.TestTools.UnitTesting;
using Google;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRandomizer.Models;

namespace Google.Tests
{
    [TestClass()]
    public class APITests
    {
        [TestMethod()]
        public void GetDataTest()
        {
            API testApi = new API();
            List<SummonerDataModel> result = testApi.GetDataAsync<SummonerDataModel>("1y-eV3NUQ-rAqSiWAq-kc7WsHc16jPABGSLkYz_yZRuY", "default").Result;
            foreach (var VARIABLE in result)
            {
               Trace.WriteLine(VARIABLE.SummonerName+" "+VARIABLE.Division);
            }
            Assert.IsNotNull(result);
        }
    }
}