using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Randomizer.Data;
using TeamRandomizer.Annotations;

namespace TeamRandomizer.Models
{
    [Serializable]
    class GroupingSettingsModel : INotifyPropertyChanged
    {
        public GroupingSettingsModel(SummonerDivisions from, SummonerDivisions to, int amount)
        {
            _from = from;
            _to = to;
            Amount = amount;
        }

        private SummonerDivisions _from;
        private SummonerDivisions _to;

        public string From
        {
            get { return _from; }
            set
            {
                _from = value;
                OnPropertyChanged();
            }
        }
        public string To {
            get { return _to; }
            set
            {
                _to = value;
                OnPropertyChanged();

            }
        }

        private int _amount;
        public int Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPropertyChanged();
            }
        }
        public ICollection<string> Divisions => SummonerDivisions.Values.Keys;

        [field:NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static implicit operator GroupingSettingsModel (GroupSetting data)
        {
            return new GroupingSettingsModel((SummonerDivisions)data.From,(SummonerDivisions)data.To,data.Number);
        }

        public static implicit operator GroupSetting (GroupingSettingsModel data)
        {
            return new GroupSetting((SummonerDivisions)data.From,(SummonerDivisions)data.To,data.Amount);
        }
    }
}
