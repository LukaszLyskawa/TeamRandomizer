using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer
{
    static class Extensions
    {
        public static IEnumerable<int> RandomizeSequenceExt(this System.Random random, int min, int max)
        {
            var sequence = new List<int>();
            for (var i = min; i <= max; i++)
            {
                sequence.Add(i);
            }
            while (sequence.Count>0)
            {
                int index = random.Next(sequence.Count);
                yield return sequence[index];
                sequence.RemoveAt(index);
            }
        } 
    }
}
