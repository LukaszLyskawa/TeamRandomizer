using Microsoft.VisualStudio.TestTools.UnitTesting;
using Randomizer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Tests
{
    [TestClass()]
    public class SampleModel
    {
        public SampleModel(string val1, string val2)
        {
            Val1 = val1;
            Val2 = val2;
        }

        public string Val1 { get; private set; }
        public string Val2 { get; private set; }
    }
    [TestClass()]
    public class SimpleTests
    {
        [TestMethod()]
        public void RandomizeTest()
        {
            var testList = new List<object>();
            for (int i = 0; i < 10; i++)
            {
                testList.Add(new SampleModel(i.ToString(), i.ToString()));
            }
            IEnumerable<object> resultList = Simple.ShuffleListAsync(testList,TimeSpan.FromSeconds(5)).Result;
            var finalList = resultList.OfType<SampleModel>();
            var variables = finalList as IList<SampleModel> ?? finalList.ToList();
            foreach (var VARIABLE in variables)
            {
                Trace.WriteLine(VARIABLE.Val1 + " " + VARIABLE.Val2);
            }
            Assert.IsInstanceOfType(variables.FirstOrDefault(), typeof(SampleModel));
        }
    }
}