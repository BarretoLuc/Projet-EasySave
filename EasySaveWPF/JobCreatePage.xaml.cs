using EasySaveLib.Controllers;
using EasySaveLib.Models;
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
    /// Logique d'interaction pour JobCreatePage.xaml
    /// </summary>
    public partial class JobCreatePage : Page, IAbstractView<JobCreateController>, IJobCreate
    {
        public JobCreateController Controller { get; set; }
        public JobCreatePage()
        {
            InitializeComponent();
        }
        public void Show()
        {
        }
        public void NewJob() 
        {
            string Name = tbNameJob.Text;
            string Source = tbSource.Text;

            //Controller.CreateJob()
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewJob();
        }
    }
}
