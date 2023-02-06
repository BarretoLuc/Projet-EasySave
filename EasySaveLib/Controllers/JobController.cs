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

        public JobController(DataStorageService StorageService)
        {
            Storage = StorageService;
        }

        public void CreateJob(string name, string sourcepath, string destinationpath)
        {
            Storage.AddJobList(
                new JobModel(name, sourcepath, destinationpath)
            );
        }
    }
}
