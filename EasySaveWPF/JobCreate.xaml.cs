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
using System.Windows.Shapes;

namespace EasySaveWPF
{
    /// <summary>
    /// Logique d'interaction pour JobCreate.xaml
    /// </summary>
    public partial class JobCreate : Window, IAbstractView<JobCreateController>, IJobCreate
    {
        private MainWindow MainWindow;
        public JobCreateController Controller { get; set; }
        public JobCreate(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
            InitializeComponent();
        }
        public void NewJob()
        {
            string name = tbNameJob.Text;
            string source = tbSource.Text;
            string destination = tbDestination.Text;
            bool isDifferentiel = false;
            bool isEncrypt = false;
            if ((bool)rbDifferential.IsChecked)
                isDifferentiel = true;
            if ((bool)cbEncrypt.IsChecked)
                isEncrypt = true;

            Controller.CreateJob(name, source, destination, isDifferentiel);
        }
        private void ResetText()
        {

            tbNameJob.Text = "";
            tbSource.Text = "";
            tbDestination.Text = "";
            cbEncrypt.IsChecked = false;
            rbDifferential.IsChecked = false;
            rbTotal.IsChecked = false;
        }
        
        private void CreateClick(object sender, RoutedEventArgs e)
        {
            NewJob();
            ResetText();
        }

        private void ClosingClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow.IsEnabled = true;
        }
    }
}
