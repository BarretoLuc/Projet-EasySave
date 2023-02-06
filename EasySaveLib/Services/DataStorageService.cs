﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveLib.Models;
using EasySaveLib.Settings;

namespace EasySaveLib.Services
{
    public class DataStorageService
    {
        public List<JobModel> JobList { get; set; }
        private SerializerService serializer;

        public DataStorageService()
        {
            JobList = new List<JobModel>();
            serializer = new SerializerService();
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
        public void RemoveJobList(JobModel job) 
        {
            foreach (var item in JobList)
            {
                if (job.Source == item.Source && job.Destination == item.Destination)
                {
                    JobList.Remove(item);
                    return;
                }
            }
            return;
        }

        public void LoadJob()
        {
            var json = System.IO.File.ReadAllText(Settings.Settings.Default.dataStorageFolder);
            JobList = serializer.Deserialize<List<JobModel>>(json);
        }
        public void SaveJob()
        {
            var json = serializer.Serialize(JobList);
            System.IO.File.WriteAllText(Settings.Settings.Default.dataStorageFolder, json);
        }

    }
}
