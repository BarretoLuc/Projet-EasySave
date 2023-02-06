using EasySaveLib.Models;
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
                CopyFile(item.FullPath, jobModel.Destination + item.Name);
            }
        }
        
        /// <summary>
        ///     Copy a file from a source to a destination.
        /// </summary>
        /// <param name="source">Source file path.</param>
        /// <param name="destination">Destination file path.</param>
        private void CopyFile(string source, string destination)
        {
            try
            {
                File.Copy(source, destination);
            }
            catch (Exception ex) { Debug.WriteLine(ex); } 
        }
    }
}
