using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TeamRandomizer.Models;

namespace FileHelper.Tests
{
    [TestClass()]
    public class TextFileTests
    {
        [TestMethod()]
        public void WriteFileTest()
        {
            var list = new List<SummonerDataModel>();
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            list.Add(new SummonerDataModel("ASD","Unranked"));
            TextFile.WriteFile(list,typeof(SummonerDataModel).GetProperties(),"D:/Test.txt");
            Assert.IsTrue(File.Exists("D:/Test.txt"));
        }
    }
}