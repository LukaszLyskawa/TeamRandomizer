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

        public static implicit operator int (SummonerDivisions data)
        {
            switch (data._value)
            {
                case "Unranked":
                    return 0;
                case "Bronze":
                    return 1;
                case "Silver":
                    return 2;
                case "Gold":
                    return 3;
                case "Platinium":
                    return 4;
                case "Diamond":
                    return 5;
                case "Master":
                    return 6;
                case "Challenger":
                    return 7;
                default:
                    return -1;
            }
        }

        public static explicit operator SummonerDivisions(int v)
        {
            switch (v)
            {
                case 0:
                    return Unranked;
                case 1:
                    return Bronze;
                case 2:
                    return Silver;
                case 3:
                    return Gold;
                case 4:
                    return Platinium;
                case 5:
                    return Diamond;
                case 6:
                    return Master;
                case 7:
                    return Challenger;
            }
            return null;
        }


    }
}
