using EasySaveLib.Controllers;
using EasySaveLib.Models;
using EasySaveLib.Services;
using EasySaveLib.Vues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveConsole.Vues
{
    internal class JobRun : IJobRun
    {
        private JobModel JobModel { get; }
        private JobController JobController { get; }

        public JobRun(DataStorageService StorageService, JobModel Job)
        {
            this.JobModel = Job;
            this.JobController = new JobController(StorageService);
        }

        public void Show()
        {
            Console.WriteLine("Job " + JobModel.Name + " is running...");
            JobController.ExecuteOneJob(JobModel);
            Console.WriteLine("Job " + JobModel.Name + " is done.");
        }
    }
}
