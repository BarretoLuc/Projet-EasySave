using System.Collections.Generic;
using EasySaveLib.Vues;
using EasySaveLib.Controllers;
using EasySaveLib.Models;

namespace EasySaveWPF.ModelViews
{
    public class ViewModel : IAbstractView<JobViewController>, IJobView
    {
        private MainWindow MainWindow;
        public JobViewController Controller { get; set; }
        public ViewModel(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
        }
        public void Show(JobModel job)
        {
        }

        public void ShowAll(List<JobModel> listJob)
        {
            MainWindow.ShowAllJob(listJob);
        }

        public void Exit()
        {
        }
    }
}
