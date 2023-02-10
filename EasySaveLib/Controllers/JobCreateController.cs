﻿using EasySaveLib.Models;
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

        public JobCreateController(IJobCreate View, DataStorageService StorageService) : base(View, StorageService)
        {
            JobService = new JobService();
        }

        public void CreateJob(string name, string sourcepath, string destinationpath, bool type)
        {
            if (Settings.Settings.Default.numberJob <= Storage.JobList.Count)
                return;
            
            var newJob = new JobModel(name, sourcepath, destinationpath, type);
            Storage.AddJobList(newJob);
        }
        

        public override void init()
        {
            View.Show();
        }
    }
}
