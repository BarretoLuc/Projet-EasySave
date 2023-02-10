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

        public JobRunController(IJobRun jobRun, DataStorageService StorageService) : base(jobRun)
        {
            Storage = StorageService;
            CopyService = new CopyService();
            JobService = new JobService();
        }

        public override void init()
        {
            JobModel job = View.ChooseJob(Storage.JobList);
            View.ShowStart(job);
            ExecuteOneJob(job);
            Storage.SaveJob();
            View.ShowEnd(job);
        }
        
        public void ExecuteOneJob(JobModel job)
        {
            job.AllFiles = JobService.GetListActionFiles(job);
            // extract and execute file to delete
            List<FileModel> filesToDelete = job.AllFiles.Where(file => file.State == State.Deleted).ToList();
            foreach (FileModel file in filesToDelete) CopyService.ExecuteAction(job, file);
            // extract and execute file no delete
            List<FileModel> filesToCopy = job.AllFiles.Where(file => file.State != State.Deleted).ToList();
            foreach (FileModel file in filesToCopy) CopyService.ExecuteAction(job, file);
        }

    }
}
