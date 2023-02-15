using EasySaveLib.Controllers;
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
            InitializeComponent();
        }
        public void showMenu()
        {
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int numberJobs = 0;
            string savePath = "";
            string dataStorageFolder = "";
            string language = "";
            bool json = (bool)cbLogJson.IsChecked;
            bool xml = (bool)cbLogJson.IsChecked;
            string pathCryptoSoft = "";

            if (Int32.TryParse(tbNumberJob.Text, out int tbNumberJobInt))
                numberJobs = tbNumberJobInt;
            if (tbSavePath.Text != null)
                savePath = tbSavePath.Text;
            if (tbDataStorageFolder.Text != null)
                dataStorageFolder = tbDataStorageFolder.Text;
            if (language != null)
                dropBoxLanguage.Text = language;
            if (tbCryptoPath.Text != null)
                pathCryptoSoft = tbCryptoPath.Text;

            Controller.ChangeSettings(numberJobs, dataStorageFolder, savePath, language, json, xml, pathCryptoSoft);
        }
    }
}
