using EasySaveLib.Models;
using System.Diagnostics;

namespace EasySaveLib.Services
{
    public class CopyService
    {
        public JobService JobService { get; set; }
        private Stopwatch Stopwatch { get; set; }

        public CopyService()
        {
            JobService = new JobService();
            Stopwatch = new Stopwatch();
        }

        public void ExecuteAction(JobModel job, FileModel file) 
        {
            Stopwatch.Start();
            switch (file.State)
            {
                case State.Waiting:
                    Copy(job, file);
                    break;
                case State.Moved:
                    Moove(job, file);
                    break;
                case State.Deleted:
                    Delete(job, file);
                    break;
                case State.Renamed:
                    Rename(job, file);
                    break;
                case State.Finished:
                    if (job.IsDifferential) break;
                    Copy(job, file);
                    break;
                default:
                    break;
            }
            Stopwatch.Stop();
            file.Time = Stopwatch.ElapsedMilliseconds;
            file.State = State.Finished;
            // TODO à revoir pour les logs
            LogService.AddLogActionJob(job.Name, job.Source, file.FullPath, job.Destination, file.Size, (int)file.Time);
        }

        private void Rename(JobModel job, FileModel file)
        {
            File.Move(file.FullPath, file.Path + file.NewName);
        }

        private void Delete(JobModel job, FileModel file)
        {
            File.Delete(file.FullPath);
        }

        private void Moove(JobModel job, FileModel file)
        {
            if (!Directory.Exists(job.Destination + file.NewPath)) Directory.CreateDirectory(job.Destination + file.NewPath);
            File.Move(file.FullPath, job.Destination + file.NewPath + file.NewName);
        }

        private void Copy(JobModel job, FileModel file)
        {
            string destinationPath = file.Path.Replace(job.Source, job.Destination);
            if (!Directory.Exists(destinationPath)) Directory.CreateDirectory(destinationPath);
            File.Copy(file.FullPath, destinationPath + file.Name);
        }
    }
}
