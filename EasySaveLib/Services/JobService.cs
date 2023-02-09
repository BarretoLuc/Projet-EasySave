﻿using EasySaveLib.Models;
using System.Diagnostics;

namespace EasySaveLib.Services
{
    public class JobService
    {
        
        /// <summary>
        ///     Coppy all files of a job.
        /// </summary>
        /// <param name="jobModel">The job.</param>
        public void CopyAllFiles(JobModel jobModel)
        {
            if (jobModel.AllFiles == null) throw new Exception("No files to copy");
            foreach (FileModel item in jobModel.AllFiles)
            {
                string destinationPath = item.Path.Replace(jobModel.Source, jobModel.Destination);
                item.Time = CopyFile(item.FullPath, destinationPath, item.Name);
                CopyFile(item.FullPath, destinationPath, item.Name);
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

        public void WalkIntoDirectory(string path, JobModel jobModel)
        {
            if (jobModel.AllFiles == null) jobModel.AllFiles = new List<FileModel>();
            
            string[] files = Directory.GetFiles(path);
            string[] dirs = Directory.GetDirectories(path);

            foreach (string file in files)
            {
                var newFile = new FileModel(file);
                newFile.Size = FileSize(newFile);
                jobModel.AllFiles.Add(newFile);
            }

            foreach (string dir in dirs)
            {
                WalkIntoDirectory(dir, jobModel);
            }
        }

        public ulong FileSize(FileModel fileModel)
        {
            return (ulong)(new FileInfo(fileModel.FullPath)).Length;
        }
    }
}
