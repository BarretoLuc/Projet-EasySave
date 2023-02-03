﻿using System;
using System.Collections.Generic;
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
            // TODO : vérifier les doublons 
            JobList.Add(job);
        }
        public void RemoveJobList() 
        {
            // TODO : A implémenter 
        }
    }
}
