using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
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
        private string folderPath = Settings.Settings.Default.dataStorageFolder;

        public DataStorageService()
        {
            JobList = new List<JobModel>();
            serializer = new SerializerService();
        }

        public void AddJobList(JobModel job) 
        {
            foreach(var item in JobList)
            {
                if (job.Source == item.Source && job.Destination == item.Destination && job.IsDifferential == item.IsDifferential)
                    return;
            }
            JobList.Add(job);
            SaveJob();
        }
        public void RemoveJobList(JobModel job) 
        {
            foreach (var item in JobList)
            {
                if (job.Source == item.Source && job.Destination == item.Destination && job.IsDifferential == item.IsDifferential)
                {
                    JobList.Remove(item);
                    return;
                }
            }
            return;
        }

        public void LoadJob()
        {
            if (!File.Exists(Settings.Settings.Default.dataStorageFolder + "job.json"))
            {
                JobList = new List<JobModel>();
                return;
            }
            var json = File.ReadAllText(Settings.Settings.Default.dataStorageFolder + "job.json"); 
            JobList = serializer.Deserialize<List<JobModel>>(json);
                
        }
        public void SaveJob()
        {
            string path = folderPath + "job.json";
            //var file = new List<JobModel>();

            //foreach (var item in JobList)
            //    file.Add(new JobModel(item.Name, item.Source, item.Destination, item.IsDifferential));

            //var json = serializer.Serialize(file);
            var json = serializer.Serialize(JobList);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            

            using (FileStream fs = File.Open(path, FileMode.OpenOrCreate))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(json);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
            }

        }
    }
}
