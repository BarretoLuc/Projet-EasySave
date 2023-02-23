using System.Collections.Generic;
using EasySaveLib.Vues;
using EasySaveLib.Controllers;
using EasySaveLib.Models;

namespace EasySaveWPF.ModelViews
{
    public class RunModel : IAbstractView<JobRunController>, IJobRun
    {
        private MainWindow MainWindow;
        public JobRunController Controller { get; set; }
        public RunModel(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
        }
        public void Show(List<JobModel> listJob)
        {
        }
        public void Progress(JobModel job)
        {
            MainWindow.Progress();
        }
        public JobModel ChooseJob(List<JobModel> jobs)
        {
            JobModel jobModel = new JobModel("", "", "");
            return jobModel;
        }
        public void RefreshJob() 
        {
            MainWindow.RefreshJob();
        }
    }
}