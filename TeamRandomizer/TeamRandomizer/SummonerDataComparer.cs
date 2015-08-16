using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRandomizer.Models;

namespace TeamRandomizer
{
    public class SummonerDataComparer : IEqualityComparer<SummonerDataModel>
    {
        public bool Equals(SummonerDataModel x, SummonerDataModel y)
        {
            return StringComparer.InvariantCultureIgnoreCase.Equals(x.SummonerName, y.SummonerName);
        }

        public int GetHashCode(SummonerDataModel obj)
        {
            return StringComparer.InvariantCultureIgnoreCase.GetHashCode(obj.SummonerName);
        }
    }
}
