using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Random.Org;
using Troschuetz.Random;

namespace Randomizer
{
    public static class Simple
    {
        public async static Task<IEnumerable<object>> ShuffleListAsync(IEnumerable<object> listToShuffle, TimeSpan timeout)
        {
            if (!listToShuffle.Any()) return new List<object>();


            var toShuffle = listToShuffle as IList<object> ?? listToShuffle.ToList();

            var getDelayedLocalVal = new Task<Task<IEnumerable<int>>>(async() =>
            {
                await Task.Delay(timeout);

                var random = new Random.Org.Random { UseLocalMode = true };

                return random.RandomizeSequence(0, toShuffle.Count() - 1);

            });

            var getRandomFromWeb = new Task<Task<IEnumerable<int>>>(async () =>
            {
                var random = new Random.Org.Random { UseLocalMode = false };
                try
                {
                    return random.RandomizeSequence(0, toShuffle.Count() - 1);
                }
                catch (WebException exception)
                {
                    Trace.WriteLine(exception);
                    await Task.Delay(TimeSpan.FromMilliseconds(timeout.TotalMilliseconds * 2));
                    // SHOULD never happen, just in case i suck
                    return await getDelayedLocalVal.Result;
                }

            });

            getDelayedLocalVal.Start();
            getRandomFromWeb.Start();

            IEnumerable<int> randomnumbers = await Task.WhenAny(getRandomFromWeb.Result, getDelayedLocalVal.Result).Result;

            return randomnumbers.Select(randomnumber => toShuffle[randomnumber]).ToList();
        }
    }
}
