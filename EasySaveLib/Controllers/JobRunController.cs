using EasySaveLib.Models;
using EasySaveLib.Services;
using EasySaveLib.Vues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Controllers
{
    public class JobRunController : AbstractController<IJobRun, JobRunController>
    {
        public JobService JobService { get; set; }

        public JobRunController(IJobRun jobRun, DataStorageService StorageService) : base(jobRun)
        {
            Storage = StorageService;
            JobService = new JobService();
        }

        public override void init()
        {
            Storage.LoadJob();
            JobModel job = View.ChooseJob(Storage.JobList);
            View.ShowStart(job);
            ExecuteOneJob(job);
            View.ShowEnd(job);
        }
        
        public void ExecuteOneJob(JobModel Job)
        {
            JobService.CopyAllFiles(Job);
        }

    }
}
