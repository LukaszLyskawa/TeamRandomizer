using Microsoft.VisualStudio.TestTools.UnitTesting;
using Randomizer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Tests
{
    [TestClass()]
    public class ComplexTests
    {
        [TestMethod()]
        public void ShuffleTest()
        {
            var summonerdata = new List<SummonerData>
            {
                new SummonerData("derp1",0),
                new SummonerData("derp2",0),
                new SummonerData("derp3",0),
                new SummonerData("derp4",0),
                new SummonerData("derp5",0),
                new SummonerData("derp6",0),
                new SummonerData("derp7",0),
                new SummonerData("derp8",0),
                new SummonerData("derp9",0),
                new SummonerData("derp10",0),
                new SummonerData("derp11",0),
                new SummonerData("derp12",0),
                new SummonerData("derp13",0),
                new SummonerData("derp14",0),
                new SummonerData("derp15",0),
                new SummonerData("derp16",0),
                new SummonerData("derp17",0),
                new SummonerData("derp18",0),
                new SummonerData("derp19",0),
                new SummonerData("derp20",0),

                new SummonerData("derp21",1),
                new SummonerData("derp22",1),
                new SummonerData("derp23",1),
                new SummonerData("derp24",1),
                new SummonerData("derp25",1),
                new SummonerData("derp26",1),
                new SummonerData("derp27",1),
                new SummonerData("derp28",1),
                new SummonerData("derp29",1),
                new SummonerData("derp30",1),
                new SummonerData("derp31",1),
                new SummonerData("derp32",1),
                new SummonerData("derp33",1),
                new SummonerData("derp34",1),
                new SummonerData("derp35",1),
                new SummonerData("derp36",1),
                new SummonerData("derp37",1),
                new SummonerData("derp38",1),
                new SummonerData("derp39",1),
                new SummonerData("derp40",1),

                new SummonerData("derp51",2),

                new SummonerData("derp41",3),
                new SummonerData("derp42",3),
                new SummonerData("derp43",3),
                new SummonerData("derp44",3),
                new SummonerData("derp45",3),
                new SummonerData("derp46",3),
                new SummonerData("derp47",3),
                new SummonerData("derp48",3),
                new SummonerData("derp49",3),
                new SummonerData("derp50",3),
            };
            var groups = new List<GroupSetting>
            {
                new GroupSetting(0, 0, 2),
                new GroupSetting(1, 2, 2),
                new GroupSetting(3, 3, 1)
            };
            var resultlist =  Complex.Shuffle(summonerdata, groups, TimeSpan.FromMilliseconds(5000)).Result;
            foreach (var data  in resultlist)
            {
                Trace.WriteLine(data.Name+" "+data.Division);
            }
            Assert.IsNotNull(resultlist);
        }
    }
}