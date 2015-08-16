using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Caliburn.Micro;
using Randomizer;
using TeamRandomizer.Models;

namespace TeamRandomizer.ViewModels
{
    class SettingsPageViewModel : Screen
    {
        public SettingsPageViewModel()
        {
            GroupingSettings = GetGroupingSettingsModels();
        }

        private ObservableCollection<GroupingSettingsModel> GetGroupingSettingsModels()
        {
            if (Properties.Settings.Default.GroupingSettings == string.Empty)
            {
                return new ObservableCollection<GroupingSettingsModel>();
            }
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(Properties.Settings.Default.GroupingSettings)))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return (ObservableCollection<GroupingSettingsModel>) bf.Deserialize(ms);
            }
        }

        private void SaveGroupingSettingsModels(ObservableCollection<GroupingSettingsModel> value)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, value);
                ms.Position = 0;
                byte[] buffer = new byte[(int)ms.Length];
                ms.Read(buffer, 0, buffer.Length);
                Properties.Settings.Default.GroupingSettings = Convert.ToBase64String(buffer);
                Properties.Settings.Default.Save();
            }
        }
        public string GoogleKey
        {
            get { return Properties.Settings.Default.GoogleKey; }
            set
            {
                Properties.Settings.Default.GoogleKey = value;
                Properties.Settings.Default.Save();
                NotifyOfPropertyChange(() => GoogleKey);
            }
        }

        public string GoogleSpreadSheetId
        {
            get { return Properties.Settings.Default.GoogleSpreadSheetID; }
            set
            {
                Properties.Settings.Default.GoogleSpreadSheetID = value;
                Properties.Settings.Default.Save();
                NotifyOfPropertyChange(() => GoogleSpreadSheetId);
            }
        }

        public RandomizeType RandomizeSetting
        {
            get { return Properties.Settings.Default.RandomizeType; }
            set
            {
                Properties.Settings.Default.RandomizeType = value;
                Properties.Settings.Default.Save();
                NotifyOfPropertyChange(() => RandomizeSetting);
            }
        }

        private ObservableCollection<GroupingSettingsModel> _groupingSettings;
        public ObservableCollection<GroupingSettingsModel> GroupingSettings
        {
            get { return _groupingSettings; }
            set
            {
                _groupingSettings = value;
                NotifyOfPropertyChange(() => GroupingSettings);
                //SaveGroupingSettingsModels(_groupingSettings);
            }
        }

        public void AddSetting()
        {
            GroupingSettings.Add(new GroupingSettingsModel("","",1));
            SaveGroupingSettingsModels(GroupingSettings);
        }

        public void DeleteGroupingSetting(object sender)
        {
            GroupingSettings.Remove(sender as GroupingSettingsModel);
            SaveGroupingSettingsModels(GroupingSettings);

        }
        protected override void OnDeactivate(bool close)
        {
            SaveGroupingSettingsModels(GroupingSettings);
            base.OnDeactivate(close);
        }
    }
}
