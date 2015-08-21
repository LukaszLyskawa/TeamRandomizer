using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using Caliburn.Micro;
using Microsoft.Win32;
using Randomizer.Data;
using TeamRandomizer.Models;
using TeamRandomizer.Properties;

namespace TeamRandomizer.ViewModels
{
    class SettingsPageViewModel : Screen
    {
        public string GoogleKey
        {
            get { return Settings.Default.GoogleKey; }
            set
            {
                Settings.Default.GoogleKey = value;
                Settings.Default.Save();
                NotifyOfPropertyChange(() => GoogleKey);
            }
        }

        public string GoogleSpreadSheetId
        {
            get { return Settings.Default.GoogleSpreadSheetID; }
            set
            {
                Settings.Default.GoogleSpreadSheetID = value;
                Settings.Default.Save();
                NotifyOfPropertyChange(() => GoogleSpreadSheetId);
            }
        }

        public string FilePath => Settings.Default.FilePath;

        public RandomizeType RandomizeSetting
        {
            get { return Settings.Default.RandomizeType; }
            set
            {
                Settings.Default.RandomizeType = value;
                Settings.Default.Save();
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
            }
        }

        public SettingsPageViewModel()
        {
            GroupingSettings = GetGroupingSettingsModels();
        }
        
        public void AddSetting()
        {
            GroupingSettings.Add(new GroupingSettingsModel("", "", 0));
            SaveGroupingSettingsModels(GroupingSettings);
        }

        public void DeleteGroupingSetting(object sender)
        {
            GroupingSettings.Remove(sender as GroupingSettingsModel);
            SaveGroupingSettingsModels(GroupingSettings);
        }

        public void SetPath()
        {
            var dialog = new SaveFileDialog
            {
                AddExtension = true,
                DefaultExt = ".txt",
                Filter = "Text File | .txt",
                CheckPathExists = true,
                InitialDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            };

            if (dialog.ShowDialog() != true) return;

            Settings.Default.FilePath = dialog.FileName;
            NotifyOfPropertyChange(() => FilePath);
        }

        private ObservableCollection<GroupingSettingsModel> GetGroupingSettingsModels()
        {
            if (Settings.Default.GroupingSettings == string.Empty)
            {
                return new ObservableCollection<GroupingSettingsModel>();
            }
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(Settings.Default.GroupingSettings)))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return (ObservableCollection<GroupingSettingsModel>)bf.Deserialize(ms);
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
                Settings.Default.GroupingSettings = Convert.ToBase64String(buffer);
                Settings.Default.Save();
            }
        }

        protected override void OnDeactivate(bool close)
        {
            SaveGroupingSettingsModels(GroupingSettings);
            base.OnDeactivate(close);
        }
    }
}
