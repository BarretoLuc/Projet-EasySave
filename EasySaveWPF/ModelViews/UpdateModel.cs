using System.Collections.Generic;
using EasySaveLib.Vues;
using EasySaveLib.Controllers;
using EasySaveLib.Models;

namespace EasySaveWPF.ModelViews
{
    public class UpdateModel : IAbstractView<JobUpdateController>, IJobUpdate
    {
        private MainWindow MainWindow;
        public JobUpdateController Controller { get; set; }
        public UpdateModel(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
        }
        public void Show()
        {
        }
        public void ShowAll(List<JobModel> listJob)
        {
        }
        public void Exit()
        {
        }
        public int AskUpdate(int count)
        {
            return 0;
        }
        public JobModel UpdateJob(JobModel job)
        {
            return job;
        }
        public void ShowError(string error)
        {
        }
    }
}
