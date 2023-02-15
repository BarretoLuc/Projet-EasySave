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
        public JobRunPage()
        {
            InitializeComponent();
        }
        public void Show(List<JobModel> jobs)
        {
        }
        public void Progress(JobModel job)
        {
        }
        public JobModel ChooseJob(List<JobModel> jobs)
        {
            JobModel jobModel = new JobModel("","","");
            return jobModel;
        }
    }
}
