using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using TeamRandomizer;
using TeamRandomizer.ViewModels;

namespace TeamRandomizer
{
    public class MainPageBootstrapper: BootstrapperBase
    {
        public MainPageBootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            Properties.Settings.Default.SummonerData = "";//clear list - testing purposes
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
