using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveLib.Models;

namespace EasySaveLib.Services
{
    public class DataStorage
    {
        public List<JobModel> JobList { get; }

        public DataStorage()
        {
            JobList = new List<JobModel>();
        }

        public void AddJobList(JobModel job) 
        {
            foreach(var item in JobList)
            {
                if (job.Source == item.Source && job.Destination == item.Destination)
                    return;
            }
            JobList.Add(job);
        }
        public void RemoveJobList() 
        {
            // TODO : A implémenter 
        }

        public void LoadJob()
        {
            // TODO A implémenter 

        }

    }
}
