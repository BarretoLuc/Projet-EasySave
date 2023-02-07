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
    public class JobCreateController : AbstractController<IJobCreate, JobCreateController>
    {
        public JobService JobService { get; set; }

        public JobCreateController(IJobCreate View,DataStorageService StorageService) : base(View)
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
        

        public override void init()
        {
            View.show();
        }
    }
}
