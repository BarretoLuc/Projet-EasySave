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
using System.Resources;
using System.Reflection;

namespace EasySaveLib.Services
{
    public class DataStorageService
    {
        public List<JobModel> JobList { get; set; }
        private SerializerService serializer;
        private ResourceManager ResourceManager { get; set; }

        public DataStorageService()
        {
            JobList = new List<JobModel>();
            serializer = new SerializerService();
            ResourceManager = new ResourceManager("EasySaveLib.Ressources.Languages." + Settings.Settings.Default.language, Assembly.GetExecutingAssembly());
        }

        public void AddJobList(JobModel job) 
        {
            foreach(var item in JobList)
            {
                if (job.Source == item.Source && job.Destination == item.Destination)
                    return;
            }
            JobList.Add(job);
            SaveJob();
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
            var json = File.ReadAllText(Settings.Settings.Default.dataStorageFolder + "job.json"); 
            JobList = serializer.Deserialize<List<JobModel>>(json);
        }
        public void SaveJob()
        {
            string folderPath = Settings.Settings.Default.dataStorageFolder;
            string path = folderPath + "job.json";
            var file = new List<JobModel>();

            foreach (var item in JobList)
                file.Add(new JobModel(item.Name, item.Source, item.Destination));
                
            var json = serializer.Serialize(file);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            

            using (FileStream fs = File.Open(path, FileMode.OpenOrCreate))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(json);
                fs.Write(bytes, 0, bytes.Length);
            }

        }

        public void ChangeLanguage(string language)
        {
            ResourceManager = new ResourceManager("EasySaveLib.Ressources.Languages." + language, Assembly.GetExecutingAssembly());
            Settings.Settings.Default.language = language;
            Settings.Settings.Default.Save();
        }

        public string GetTranslation(string key)
        {
            return ResourceManager.GetString(key) ?? throw new KeyNotFoundException();
        }
    }
}
