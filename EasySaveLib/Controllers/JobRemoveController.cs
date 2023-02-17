using EasySaveLib.Services;
using EasySaveLib.Vues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Controllers
{
    public class JobRemoveController : AbstractController<IJobRemove, JobRemoveController>
    {
        private StateService StateService { get; set; }

        public JobRemoveController(IJobRemove view, DataStorageService? StorageService = null) : base(view, StorageService)
        {
            StateService = new StateService();
        }

        public override void init()
        {
            if (Storage.JobList.Count == 0)
            {
                View.ShowError("jobRemove_error_jobListEmpty");
                View.EndMessage();
                return;
            }
            View.ShowJobs(Storage.JobList);
        }
        public void RemoveSelection()
        {
            int jobId = View.ChooseJob(Storage.JobList.Count);
            if (jobId != 0)
            {
                Storage.JobList.RemoveAt(jobId - 1);
                StateService.SaveJob(Storage.JobList);
                View.EndMessage(true);
            }
        }
    }
}
