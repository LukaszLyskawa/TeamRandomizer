using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using Caliburn.Micro;
using TeamRandomizer.ViewModels;

namespace TeamRandomizer.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        public ShellView()
        {
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pl");
            InitializeComponent();
            
        }

        private void Toolbar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void Toolbar_OnSettingsClicked(object sender, RoutedEventArgs e)
        {
            if ((sender as ToggleButton).IsChecked.Value)
            {
                (DataContext as ShellViewModel).ShowSettingsPage();
            }
            else
            {
                (DataContext as ShellViewModel).ShowMainPage();
            }
        }
    }
}
