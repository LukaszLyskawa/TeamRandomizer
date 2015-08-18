using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using Caliburn.Micro;
using Google;
using Randomizer;
using TeamRandomizer.Models;
using static System.String;

namespace TeamRandomizer.ViewModels
{
    class MainPageViewModel : Screen
    {
        private Visibility _loadingVisibility = Visibility.Collapsed;

        public IEnumerable<SummonerDataModel> PlayerList
        {
            get
            {
                if (Properties.Settings.Default.SummonerData == Empty)
                {
                    return new List<SummonerDataModel>();
                }
                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(Properties.Settings.Default.SummonerData)))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    return (List<SummonerDataModel>)bf.Deserialize(ms);
                }
            }
            set
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(ms, value);
                    ms.Position = 0;
                    byte[] buffer = new byte[(int)ms.Length];
                    ms.Read(buffer, 0, buffer.Length);
                    Properties.Settings.Default.SummonerData = Convert.ToBase64String(buffer);
                    Properties.Settings.Default.Save();
                }
                NotifyOfPropertyChange(() => PlayerList);
            }
        }

        public Visibility LoadingVisibility
        {
            get { return _loadingVisibility; }
            private set
            {
                _loadingVisibility = value;
                NotifyOfPropertyChange(() => LoadingVisibility);
            }
        }

        public void Clear()
        {
            PlayerList = new List<SummonerDataModel>();
        }

        public async void Randomize()
        {
            LoadingVisibility = Visibility.Visible;
            switch (Properties.Settings.Default.RandomizeType)
            {
                case RandomizeType.Simple:
                    {
                        await Task.Run(async () =>
                        {
                            PlayerList = (await Randomizer.Simple.ShuffleListAsync(PlayerList, TimeSpan.FromSeconds(5))).OfType<SummonerDataModel>().ToList();
                        });
                        break;
                    }
                case RandomizeType.Grouped:
                    {
                        //TODO cast SummonerDataModel -> Randomizer.SummonerData
                        //TODO get grouping settings (use settings page view model method -> maybe extract to class)
                        //PlayerList =
                        //    await
                        //        Randomizer.Complex.Shuffle(PlayerList,Properties.Settings.Default.GroupingSettings,
                        //            TimeSpan.FromSeconds(5));
                        break;
                    }
            }

            LoadingVisibility = Visibility.Collapsed;
        }

        public async void Import()
        {
            LoadingVisibility = Visibility.Visible;
            API googleApi = new API();
            PlayerList = await googleApi.GetDataAsync<SummonerDataModel>(Properties.Settings.Default.GoogleKey, Properties.Settings.Default.GoogleSpreadSheetID);
            PlayerList = PlayerList.Distinct().ToList();
            LoadingVisibility = Visibility.Collapsed;
        }

        public void Export()
        {
            LoadingVisibility = Visibility.Visible;
            //TODO create excel/xml/json/?
            //TODO Team visualization
            LoadingVisibility = Visibility.Collapsed;
        }
    }
}
