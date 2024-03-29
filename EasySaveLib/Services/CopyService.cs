﻿using EasySaveLib.Models;
using System.Diagnostics;

namespace EasySaveLib.Services
{
    public class CopyService
    {
        private Stopwatch Stopwatch { get; set; }
        private StateService StateService { get; set; }

        public CopyService()
        {
            Stopwatch = new Stopwatch();
            StateService = new StateService();
        }

        public void ExecuteAction(JobModel job, FileModel file, DataStorageService Storage)
        {
            Stopwatch.Start();
            switch (file.State)
            {
                case State.Waiting:
                    if (job.IsEncrypted) CopyEncrypt(job, file);
                    else Copy(job, file);
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
                    break;
                default:
                    break;
            }
            Stopwatch.Stop();
            file.Time = Stopwatch.ElapsedMilliseconds;
            file.State = State.Finished;
            LogService.AddLogActionJob(job.Name, job.Source, file.FullPath, job.Destination, file.Size, (int)file.Time);
            StateService.SaveJob(Storage.JobList);
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
            File.Move(file.FullPath, job.Destination + file.NewPath + file.NewName, overwrite: true);
        }

        private void Copy(JobModel job, FileModel file)
        {
            string destinationPath = file.Path.Replace(job.Source, job.Destination);
            if (!Directory.Exists(destinationPath)) Directory.CreateDirectory(destinationPath);
            File.Copy(file.FullPath, destinationPath + file.Name, overwrite: true);
        }

        private void CopyEncrypt(JobModel job, FileModel file)
        {
            string destinationPath = file.Path.Replace(job.Source, job.Destination);
            if (!Directory.Exists(destinationPath)) Directory.CreateDirectory(destinationPath);
            Process process = new Process();
            process.StartInfo.FileName = Settings.Settings.Default.pathCryptoSoft;
            Console.WriteLine(file.FullPath + " " + destinationPath + file.Name + ".xor" + " pass");
            process.StartInfo.Arguments = file.FullPath + " " + destinationPath + file.Name + ".xor" + " pass";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            process.WaitForExit();
        }
    }
}
