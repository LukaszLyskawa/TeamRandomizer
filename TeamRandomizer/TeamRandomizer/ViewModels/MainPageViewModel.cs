using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using Caliburn.Micro;
using Google;
using Randomizer;
using Randomizer.Data;
using TeamRandomizer.Models;
using static System.String;
using SummonerData = Randomizer.Data.SummonerData;

namespace TeamRandomizer.ViewModels
{
    class MainPageViewModel : Screen
    {
        private Visibility _loadingVisibility = Visibility.Collapsed;

        public IEnumerable<SummonerDataModel> PlayerList
        {
            get
            {
                return Properties.Settings.Default.SummonerData == Empty ? new List<SummonerDataModel>() : StringToObjectHelper.CastFromString<List<SummonerDataModel>>(Properties.Settings.Default.SummonerData);
            }
            set
            {
                Properties.Settings.Default.SummonerData = StringToObjectHelper.CastToString(value);
                Properties.Settings.Default.Save();
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

                        PlayerList = (await Randomizer.Complex.Shuffle(PlayerList.Select(player => (SummonerData)player),StringToObjectHelper.CastFromString<ObservableCollection<GroupingSettingsModel>>(Properties.Settings.Default.GroupingSettings).Select(setting => (GroupSetting)setting), TimeSpan.FromSeconds(5))).Select(entry => (SummonerDataModel)entry).ToList();
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
