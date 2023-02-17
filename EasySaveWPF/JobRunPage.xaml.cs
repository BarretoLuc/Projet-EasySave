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
    /// Logique d'interaction pour JobRunPage.xaml
    /// </summary>
    public partial class JobRunPage : Page, IAbstractView<JobRunController>, IJobRun
    {
        public JobRunController Controller { get; set; }
        private List<JobModel> ListJob;
        public JobRunPage()
        {
        }
        public void Show(List<JobModel> listJob)
        {
            InitializeComponent();
            ListJob = listJob;
            dgJob.ItemsSource = ListJob;
        }
        public void Progress(JobModel job)
        {
            pbExecute.Value++;
        }
        public JobModel ChooseJob(List<JobModel> jobs)
        {
            JobModel jobModel = new JobModel("","","");
            return jobModel;
        }

        private void ExecuteClick(object sender, RoutedEventArgs e)
        {
            if (dgJob.SelectedItems.Count <= 0)
                return;
            
            if (dgJob.SelectedItems.Count == 1)
                Controller.ExecuteOneJob(ListJob[dgJob.SelectedIndex]);
            else if (dgJob.SelectedItems.Count > 1)
            {
                foreach (JobModel item in dgJob.SelectedItems)
                {
                    Controller.ExecuteOneJob(item);
                }
            }
        }
    }
}
