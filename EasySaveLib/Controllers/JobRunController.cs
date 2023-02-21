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
        private JobService JobService { get; set; }

        public JobRunController(IJobRun View, DataStorageService StorageService) : base(View, StorageService)
        {
            JobService = new JobService();
        }

        public override void init()
        {
            View.Show(Storage.JobList);
        }

        public void ExecuteAllJob()
        {
            foreach (JobModel job in Storage.JobList)
            {
                ExecuteOneJob(job);
            }
        }

        public void ExecuteOneJob(JobModel job)
        {
            View.Progress(job);
            ThreadPool.QueueUserWorkItem((a) =>
            {
                JobService.ExecuteJob(job, Storage);
            });
        }

    }
}
