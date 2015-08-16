using Caliburn.Micro;

namespace TeamRandomizer.ViewModels
{
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive
    {
        public ShellViewModel()
        {
            ShowMainPage();
        }

        public void ShowMainPage()
        {
            ActivateItem(new MainPageViewModel());
        }

        public void ShowSettingsPage()
        {
            ActivateItem(new SettingsPageViewModel());
        }
    }
}