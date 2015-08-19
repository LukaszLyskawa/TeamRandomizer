using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Data
{
    [Serializable]
    public class SummonerData
    {
        public SummonerData(string name, int division)
        {
            Name = name;
            Division = division;
        }

        public string Name { get; }
        public int Division { get; }
    }
}
