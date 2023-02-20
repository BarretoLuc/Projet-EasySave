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
    /// Logique d'interaction pour JobRemovePage.xaml
    /// </summary>
    public partial class JobRemovePage : Page, IAbstractView<JobRemoveController>, IJobRemove
    {
        public JobRemoveController Controller { get; set; }
        private List<JobModel> ListJobShow;
        public JobRemovePage()
        {
        }
        public void ShowJobs(List<JobModel> jobs)
        {
            InitializeComponent();
            ListJobShow = jobs;
            dgJob.ItemsSource = ListJobShow;
        }
        public int ChooseJob(int listJobLength)
        {
            if (dgJob.SelectedItems.Count <= 0)
                return 0;
            
            else if (dgJob.SelectedItems.Count == 1)
            {
                if (dgJob.SelectedIndex != -1)
                {
                    int id = dgJob.SelectedIndex;
                    return id+1;
                }
            }
            return 0;
        }
        public void ShowError(string error)
        {
        }
        public void EndMessage(bool success)
        {
        }

        private void RemoveClick(object sender, RoutedEventArgs e)
        {
            Controller.RemoveSelection();
            dgJob.ItemsSource = null;
            dgJob.ItemsSource = ListJobShow;
        }
    }
}
