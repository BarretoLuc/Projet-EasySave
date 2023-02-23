using EasySaveLib.Controllers;
using EasySaveLib.Vues;
using EasySaveLib.Services;
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
using System.Windows.Shapes;
using EasySaveLib.Settings;

namespace EasySaveWPF
{
    /// <summary>
    /// Logique d'interaction pour SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window, IAbstractView<SettingsController>, ISettings
    {
        public SettingsController Controller { get; set; }
        public MainWindow MainWindow { get; set; }
        public string[] software;  
        public SettingsWindow(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
        }

        public string[] GetSoftware()
        {
            return software;
        }

        public void showMenu()
        {
            InitializeComponent();
            InitRadioButton();
            var softwareServices = new SoftwareRunningService();
            software = softwareServices.GetSoftware();
        }

        private void InitRadioButton()
        {
            if (Settings.Default.language == "francais")
                rbFr.IsChecked = true;
            else
                rbEn.IsChecked = true;
        }

        private void ApplySettingsButton_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)rbFr.IsChecked)
                Settings.Default.language = "francais";
            else
                Settings.Default.language = "english";
            Settings.Default.Save();
            MainWindow.IsEnabled = true;
            this.Close();
        }

        private void ClosingClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow.IsEnabled = true;
        }
    }
}
