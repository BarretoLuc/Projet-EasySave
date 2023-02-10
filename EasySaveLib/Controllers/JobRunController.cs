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

        public JobRunController(IJobRun View, DataStorageService StorageService) : base(View, StorageService)
        {
            CopyService = new CopyService();
            JobService = new JobService();
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
                Storage.SaveJob();
                //Mettre une vue d'information de l'avancement.
            }
        }


        public void ExecuteOneJob(JobModel job)
        {
            job.AllFiles = JobService.GetListActionFiles(job);
            // extract and execute file to delete
            List<FileModel> filesToDelete = job.AllFiles.Where(file => file.State == State.Deleted).ToList();
            foreach (FileModel file in filesToDelete) CopyService.ExecuteAction(job, file);
            // extract and execute file no delete
            List<FileModel> filesToCopy = job.AllFiles.Where(file => file.State != State.Deleted).ToList();
            foreach (FileModel file in filesToCopy) ThreadPool.QueueUserWorkItem((a) => { CopyService.ExecuteAction(job, file); });
        }

    }
}
