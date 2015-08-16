using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TeamRandomizer.Models
{
    [Serializable]
    public class SummonerDataModel
    {
        public string SummonerName { get; }
        public string Division { get;}
        public SummonerDataModel(string summonerName, string division)
        {
            SummonerName = summonerName;
            Division = division;
        }

        public override bool Equals(object obj)
        {
            var summonerDataModel = obj as SummonerDataModel;
            return summonerDataModel != null &&
                   StringComparer.InvariantCultureIgnoreCase.Equals(SummonerName, summonerDataModel.SummonerName);
        }

        public override int GetHashCode()
        {
            return StringComparer.InvariantCultureIgnoreCase.GetHashCode(SummonerName);
        }
    }
}
