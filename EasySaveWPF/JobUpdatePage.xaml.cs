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
    /// Logique d'interaction pour JobUpdatePage.xaml
    /// </summary>
    public partial class JobUpdatePage : Page, IAbstractView<JobUpdateController>, IJobUpdate
    {
        public JobUpdateController Controller { get; set; }
        public JobUpdatePage()
        {
            InitializeComponent();
        }
        public void ShowAll(List<JobModel> jobs)
        {
        }
        public void Show()
        {
        }
        public void Exit()
        {
        }
        public int AskUpdate(int listJobLength) 
        {
            return 0;
        }

        public JobModel UpdateJob(JobModel job) 
        {
            return job;
        }
        public void ShowError(string key) 
        { 
        }
    }
}
