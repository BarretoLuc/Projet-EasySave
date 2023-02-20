using EasySaveLib.Controllers;
using EasySaveLib.Settings;
using EasySaveLib.Vues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// CECI EST LA VERSION A GARDER 

namespace EasySaveWPF
{
    /// <summary>
    /// Logique d'interaction pour SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page, IAbstractView<SettingsController>, ISettings
    {
        public SettingsController Controller { get; set; }

        public SettingsPage()
        {
            Controller = new SettingsController(this, new EasySaveLib.Services.DataStorageService());
        }
        public void showMenu()
        {
            InitializeComponent();
            InitRadioButton();
        }

        private void InitRadioButton()
        {
            if (Settings.Default.language == "francais")
                rbFr.IsChecked = true;
            else
                rbEn.IsChecked = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)rbFr.IsChecked)
                Settings.Default.language = "francais";
            else
                Settings.Default.language = "english";
            Settings.Default.Save();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
        }
    }
}
