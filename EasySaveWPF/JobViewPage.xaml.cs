using EasySaveLib.Controllers;
using EasySaveLib.Vues;
using EasySaveLib.Models;
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
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class JobViewPage : Page, IAbstractView<JobViewController>, IJobView
    {
        public JobViewController Controller { get; set; }
        private List<JobModel> ListJob;
        public JobViewPage()
        {

        }

        public void Show(JobModel job)
        {
        }
        public void ShowAll(List<JobModel> listJob)
        {
            InitializeComponent();
            ListJob = listJob;
            dgJob.ItemsSource = ListJob;
        }

        public void Exit()
        { 
        }

        private void JobSelected(object sender, SelectionChangedEventArgs e)
        {
            if (dgJob.SelectedIndex != -1)
                dgFile.ItemsSource = ListJob[dgJob.SelectedIndex].AllFiles;
        }
    }
}
