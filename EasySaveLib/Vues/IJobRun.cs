using EasySaveLib.Controllers;
using EasySaveLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Vues
{
    public interface IJobRun : IAbstractView<JobRunController>
    {
        public JobModel ChooseJob(List<JobModel> jobs);
        public void Show(List<JobModel> jobs);
    }
}
