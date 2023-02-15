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
        public JobRemovePage()
        {
            InitializeComponent();
        }
        public void ShowJobs(List<JobModel> jobs)
        {
        }
        public int ChooseJob(int id)
        {
            
            return 0;
        }
        public void ShowError(string error)
        {
        }
        public void EndMessage(bool success)
        {
        }
        
    }
}
