using EasySaveLib.Controllers;
using EasySaveLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Vues
{
    public interface IJobRemove : IAbstractView<JobRemoveController>
    {
        public void ShowJobs(List<JobModel> jobs);
        public int ChooseJob(int listJobLength);
        public void EndMessage(bool success = false);
        public void ShowError(string key);
    }
}
