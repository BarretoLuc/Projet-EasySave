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
        private ResourceManager ResourceManager { get; set; }
        private StateService StateService { get; set; }

        public DataStorageService()
        {
            JobList = new List<JobModel>();
            ResourceManager = new ResourceManager("EasySaveLib.Ressources.Languages." + Settings.Settings.Default.language, Assembly.GetExecutingAssembly());
            StateService = new StateService();
        }

        public void AddJobList(JobModel job) 
        {
            foreach(var item in JobList)
            {
                if (job.Source == item.Source && job.Destination == item.Destination && job.IsDifferential == item.IsDifferential)
                    return;
            }
            JobList.Add(job);
            StateService.SaveJob(JobList);
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
