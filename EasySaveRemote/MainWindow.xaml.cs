using EasySaveLib.Models;
using EasySaveLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace EasySaveRemote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Mutex mutex = new Mutex(true, "EasySave");

        private List<JobModel> ListJob;

        private ClientRemoteService ClientRemoteService;

        public MainWindow()
        {
            InitializeComponent();
            ClientRemoteService = new ClientRemoteService();
            RefreshJob();
        }

        public void RefreshJob()
        {
            dgJob.ItemsSource = null;
            dgJob.ItemsSource = ClientRemoteService.GetJobs();
        }

        private void JobSelected(object sender, SelectionChangedEventArgs e)
        {
            if (dgJob.SelectedIndex != -1)
                dgFile.ItemsSource = ListJob[dgJob.SelectedIndex].AllFiles;
        }

        private void StopClick(object sender, RoutedEventArgs e)
        {
            if (dgJob.SelectedItems.Count <= 0)
                return;

            if (dgJob.SelectedItems.Count == 1)
            {
                //Controller.PauseOneJob(ListJob[dgJob.SelectedIndex]);   
            }
            else if (dgJob.SelectedItems.Count > 1)
            {
                foreach (JobModel item in dgJob.SelectedItems)
                {
                    //Controller.PauseOneJob(item);
                }
            }
            RefreshJob();
        }

        private void StartClick(object sender, RoutedEventArgs e)
        {
            if (dgJob.SelectedItems.Count <= 0)
                return;

            if (dgJob.SelectedItems.Count == 1)
            {
                //Controller.ExecuteOneJob(ListJob[dgJob.SelectedIndex]);
            }
            else if (dgJob.SelectedItems.Count > 1)
            {
                foreach (JobModel item in dgJob.SelectedItems)
                {
                    //Controller.ExecuteOneJob(item);
                }
            }
            RefreshJob();
        }

        private void RefreshClick(object sender, RoutedEventArgs e)
        {
            RefreshJob();
        }

        private void ClosingClick(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
