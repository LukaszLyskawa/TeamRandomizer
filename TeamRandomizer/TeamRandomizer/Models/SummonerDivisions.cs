using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRandomizer.Models
{
    [Serializable]
    public sealed class SummonerDivisions
    {
        public static readonly SummonerDivisions Unranked = new SummonerDivisions("Unranked");
        public static readonly SummonerDivisions Bronze = new SummonerDivisions("Bronze");
        public static readonly SummonerDivisions Silver = new SummonerDivisions("Silver");
        public static readonly SummonerDivisions Gold = new SummonerDivisions("Gold");
        public static readonly SummonerDivisions Platinium = new SummonerDivisions("Platinium");
        public static readonly SummonerDivisions Diamond = new SummonerDivisions("Diamond");
        public static readonly SummonerDivisions Master = new SummonerDivisions("Master");
        public static readonly SummonerDivisions Challenger = new SummonerDivisions("Challenger");
        public static readonly Dictionary<string,SummonerDivisions> Values=new Dictionary<string, SummonerDivisions>();
        private readonly string _value;

        static SummonerDivisions()
        {
            Values.Add(Unranked._value,Unranked);
            Values.Add(Bronze._value,Bronze);
            Values.Add(Silver._value,Silver);
            Values.Add(Gold._value,Gold);
            Values.Add(Platinium._value,Platinium);
            Values.Add(Diamond._value,Diamond);
            Values.Add(Master._value,Master);
            Values.Add(Challenger._value,Challenger);
        }
        private SummonerDivisions(string name)
        {
            _value = name;
        }

        public static implicit operator SummonerDivisions(string value)
        {
            return value == "" ? Values["Unranked"] : Values[value];
        }

        public static implicit operator string(SummonerDivisions value)
        {
            return value._value;
        }

    }
}
