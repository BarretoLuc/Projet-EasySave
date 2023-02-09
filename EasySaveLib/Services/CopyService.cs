using EasySaveLib.Models;
using System.Diagnostics;

namespace EasySaveLib.Services
{
    public class CopyService
    {
        public JobService JobService { get; set; }

        public CopyService()
        {
            JobService = new JobService();
        }

        public void ExecuteAction(JobModel job, FileModel file) 
        {
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
            file.State = State.Finished;
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
            CopyFile(file.FullPath, destinationPath, file.Name);
        }



        /// <summary>
        ///     Coppy all files of a job.
        /// </summary>
        /// <param name="jobModel">The job.</param>
        private void CopyAllFiles(JobModel jobModel)
        {
            //JobService.WalkIntoDirectory(jobModel.Source, jobModel);
            if (jobModel.AllFiles == null) throw new Exception("No files to copy");
            if (jobModel.AllFiles.Count == 0) throw new Exception("TODO");
            foreach (FileModel item in jobModel.AllFiles)
            {
                string destinationPath = item.Path.Replace(jobModel.Source, jobModel.Destination);
                item.Time = CopyFile(item.FullPath, destinationPath, item.Name);
                CopyFile(item.FullPath, destinationPath, item.Name);
                item.State = State.Finished;
                LogService.AddLogActionJob(jobModel.Name, jobModel.Source, item.FullPath, jobModel.Destination, item.Size, 1);
            }
        }

        /// <summary>
        ///     Copy a file from a source to a destination.
        /// </summary>
        /// <param name="source">Source file path.</param>
        /// <param name="destinationPath">Destination file path.</param>
        /// <param name="destinationName">Destination file name.</param>
        private long CopyFile(string source, string destinationPath, string destinationName)
        {
            Stopwatch stopwatchfilecopy = new Stopwatch();
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }
            try
            {
                stopwatchfilecopy.Start();
                File.Copy(source, destinationPath + destinationName);
                stopwatchfilecopy.Stop();
            }
            catch (Exception ex) { Debug.WriteLine(ex); }

            return stopwatchfilecopy.ElapsedMilliseconds;
        }
    }
}
