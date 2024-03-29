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
    public class HomeController : AbstractController<IHome, HomeController>
    {
        public HomeController(IHome View) : base(View, new DataStorageService()) 
        {
            new LogService();
            ResetStateJob();
        }

        private void ResetStateJob()
        {
            foreach (JobModel job in Storage.JobList)
                if (job.State == JobStatsEnum.Running)
                    job.State = JobStatsEnum.Pause;
        }

        public override void init()
        {
            Storage.JobList = (new StateService()).LoadJob();
            ThreadPool.QueueUserWorkItem((a) => { new ServerRemoteService(Storage).StartServer(); });
            View.showMenu();
        }
        public void AccessSave(IJobCreate jobCreate)
        {
            JobCreateController jobController = new JobCreateController(jobCreate, Storage);
            jobController.init();
        }

        public void ShowJobRun(IJobRun jobRun)
        {
            JobRunController jobRunController = new JobRunController(jobRun, Storage);
            jobRunController.init();
        }

        public void ShowJobViews(IJobView jobView)
        {
            JobViewController jobViewController = new JobViewController(jobView, Storage);
            jobViewController.init();
        }

        public void ShowSettings(ISettings settings)
        {
            SettingsController settingsController = new SettingsController(settings, Storage);
            settingsController.init();
        }

        public void ShowJobUpdate(IJobUpdate jobUpdate)
        {
            JobUpdateController jobUpdateController = new JobUpdateController(jobUpdate, Storage);
            jobUpdateController.init();
        }

        public void ShowJobRemove(IJobRemove jobRemove)
        {
            JobRemoveController jobRemoveController = new JobRemoveController(jobRemove, Storage);
            jobRemoveController.init();
        }

    }
}
