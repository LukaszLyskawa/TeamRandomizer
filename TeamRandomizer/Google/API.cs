using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Google.GData.Spreadsheets;
using Google.GData.Client;
using Google.GData.Extensions;

namespace Google
{
    public class API
    {
        readonly SpreadsheetsService _myService = new SpreadsheetsService("MySpreadsheetIntegration");
        /// <summary>
        /// Temporary solution, data has to have 2 columns
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">Google spreadsheet key (check url for long parameter with dashes)</param>
        /// <param name="worksheetid">Keep default(?)</param>
        /// <returns></returns>
        public async Task<List<T>> GetDataAsync<T>(string key, string worksheetid)
        {

            CellQuery query = new CellQuery(key, worksheetid, "public", "basic");

            CellFeed cellFeed = await Task.Run(() =>
            {
                try
                {
                    return _myService.Query(query);
                }
                catch (GDataRequestException exception)
                {
                    return null;
                }

            });
            if (cellFeed == null)
            {
                return new List<T> { (T)Activator.CreateInstance(typeof(T), "Error while fetching data from google", "") };
            }
            if (cellFeed.Entries.Count == 0)
            {
                return new List<T> { (T)Activator.CreateInstance(typeof(T), "Empty", "") };
            }
            var result = new List<T>();
            for (int i = 3; i < cellFeed.Entries.Count - 1; i += 3)
            {
                //skip header (i=3), skip timeline i+1,i+2, i+=3
                result.Add((T)Activator.CreateInstance(typeof(T), cellFeed.Entries[i + 1].Content.Content, cellFeed.Entries[i + 2].Content.Content));
            }

            return result;

        }
    }
}
