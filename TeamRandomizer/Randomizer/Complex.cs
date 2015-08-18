using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Randomizer
{
    //Crap code :/
    public static class Complex
    {
        private static IEnumerable<GroupSetting> _groups;
        private static IEnumerable<SummonerData> _summonerData;
        public async static Task<IEnumerable<SummonerData>> Shuffle(IEnumerable<SummonerData> Summoners, IEnumerable<GroupSetting> Groups, TimeSpan timeout)
        {
            _summonerData = Summoners;
            _groups = Groups;
            Summoners = (await Simple.ShuffleListAsync(Summoners, timeout)).OfType<SummonerData>().ToList();
            return CreateTeams(DivideSummoner(Summoners));
            //.SelectMany(summonergroup => summonergroup).ToList()
        }

        private static IEnumerable<SummonerData> CreateTeams(List<List<SummonerData>> SummonerGroups)
        {
            var resultlist = new List<SummonerData>();
            
            while (resultlist.Count < _summonerData.Count())
            {
                var iteration = 0;
                foreach (var group in _groups)
                {
                    for (var i = 0; i < group.Number; i++)
                    {
                        if (SummonerGroups[iteration].Any())
                        {
                            resultlist.Add(SummonerGroups[iteration].First());
                            SummonerGroups[iteration].Remove(SummonerGroups[iteration].First());
                        }
                    }
                    iteration++;
                }
            }

            return resultlist;
        }
        private static List<List<SummonerData>> DivideSummoner(IEnumerable<SummonerData> Summoners)
        {
            var resultList = new List<List<SummonerData>>();
            var i = 0;

            foreach (var group in _groups)
            {
                resultList.Add(new List<SummonerData>());
                foreach (var summoner in Summoners)
                {
                    if (summoner.Division >= group.From && summoner.Division <= group.To)
                        resultList[i].Add(summoner);
                }
                i++;
            }
            return resultList;

        }
    }

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

    public class GroupSetting
    {
        public GroupSetting(int from, int to, int number)
        {
            From = from;
            To = to;
            Number = number;
        }

        public int From { get; }
        public int To { get; }
        public int Number { get; }
    }
}
