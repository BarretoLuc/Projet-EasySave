using System.Collections.Generic;
using EasySaveLib.Vues;
using EasySaveLib.Controllers;
using EasySaveLib.Models;

namespace EasySaveWPF.ModelViews
{
    public class RemoveModel : IAbstractView<JobRemoveController>, IJobRemove
    {
        private MainWindow MainWindow;
        public JobRemoveController Controller { get; set; }
        public RemoveModel(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
        }
        public void ShowJobs(List<JobModel> jobs)
        {
        }
        public int ChooseJob(int listJobLength)
        {
            int ret = MainWindow.ChooseJobRemove(listJobLength);
            return ret;
        }
        public void ShowError(string error)
        {
        }
        public void EndMessage(bool success)
        {
        }
    }
}
