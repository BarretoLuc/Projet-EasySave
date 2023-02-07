using EasySaveLib.Models;
using EasySaveLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Controllers
{
    public class JobController : AbstractController
    {
        public new DataStorageService Storage { get; }
        public JobService JobService { get; set; }

        public JobController(DataStorageService StorageService)
        {
            Storage = StorageService;
            JobService = new JobService();
        }

        public void CreateJob(string name, string sourcepath, string destinationpath)
        {
            var newJob = new JobModel(name, sourcepath, destinationpath);
            JobService.WalkIntoDirectory(sourcepath, newJob);
            Storage.AddJobList(newJob);
        }

        public void ExecuteOneJob(JobModel Job)
        {
            JobService.CopyAllFiles(Job);
        }
    }
}
