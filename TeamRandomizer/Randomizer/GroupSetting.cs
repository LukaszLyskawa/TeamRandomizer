using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Data
{
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
