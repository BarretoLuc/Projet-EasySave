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
    public class JobRunController : AbstractController<IJobRun, JobRunController>
    {
        public JobService JobService { get; set; }
        public CopyService CopyService { get; set; }
        private StateService StateService { get; set; }
        private SoftwareRunningService SoftwareRunningService { get; set; }

        public JobRunController(IJobRun View, DataStorageService StorageService) : base(View, StorageService)
        {
            CopyService = new CopyService();
            JobService = new JobService();
            StateService = new StateService();
            SoftwareRunningService = new SoftwareRunningService();
        }

        public override void init()
        {
            View.Show(Storage.JobList);
        }

        public void ExecuteAllJob()
        {
            foreach (JobModel job in Storage.JobList)
            {
                ExecuteOneJob(job);
            }
        }


        public void ExecuteOneJob(JobModel job)
        {
            View.Progress(job);
            // Si le job n'est pas en pause, calculer les actions à effectuer
            if (job.State == JobStatsEnum.NotStarted || job.State == JobStatsEnum.Finished)
                job.AllFiles = JobService.GetListActionFiles(job);
            StateService.SaveJob(Storage.JobList);
            // extract and execute file to delete
            List<FileModel> filesToDelete = job.AllFiles.Where(file => file.State == State.Deleted).ToList();
            foreach (FileModel file in filesToDelete) CopyService.ExecuteAction(job, file, Storage);
            // extract and execute file no delete
            List<FileModel> filesToCopy = job.AllFiles.Where(file => file.State != State.Deleted).ToList();
            foreach (FileModel file in filesToCopy)
            {
                if (SoftwareRunningService.IsRunningSoftware())
                {
                    job.State = JobStatsEnum.Pause;
                    StateService.SaveJob(Storage.JobList);
                    return;
                } else ThreadPool.QueueUserWorkItem((a) => { CopyService.ExecuteAction(job, file); });
            }
            job.State = JobStatsEnum.Finished;
            StateService.SaveJob(Storage.JobList);
        }

    }
}
