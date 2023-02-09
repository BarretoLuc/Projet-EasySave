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
        public CopyService CopyService { get; set; }

        public JobRunController(IJobRun jobRun, DataStorageService StorageService) : base(jobRun)
        {
            Storage = StorageService;
            CopyService = new CopyService();
        }

        public override void init()
        {
            JobModel job = View.ChooseJob(Storage.JobList);
            ExecuteOneJob(job);
        }
        
        public void ExecuteOneJob(JobModel Job)
        {
            CopyService.CopyAllFiles(Job);
        }

    }
}
