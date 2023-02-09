using EasySaveLib.Models;

namespace EasySaveLib.Services
{
    public class JobService
    {
        public List<FileModel> GetListActionFiles(JobModel jobModel)
        {
            var filesSource = WalkIntoDirectory(jobModel.Source);
            var filesDestination = WalkIntoDirectory(jobModel.Destination);
            var filesAction = new List<FileModel>();

            ComputeHash(filesSource);
            ComputeHash(filesDestination);
            
            return GetFilesToCopy(filesSource, filesDestination);
        }

        private List<FileModel> GetFilesToCopy(List<FileModel> filesSource, List<FileModel> filesDestination)
        {
            var filesToCopy = new List<FileModel>();
            foreach (var fileSource in filesSource)
            {
                var fileDestination = filesDestination.Find(x => x.Hash == fileSource.Hash);

                if (fileDestination == null)
                {
                    fileSource.State = State.Waiting;
                    filesToCopy.Add(fileSource);
                    continue;
                }

                filesDestination.Remove(fileDestination);

                // check relative path
                if (fileSource.RelativePath != fileDestination.RelativePath)
                {
                    fileSource.State = State.Moved;
                    filesToCopy.Add(fileSource);
                    continue;
                }

                fileSource.State = State.Finished;
                filesToCopy.Add(fileSource);
            }

            // check file destination need to delete
            foreach (var fileDestination in filesDestination)
            {
                fileDestination.State = State.Deleted;
                filesToCopy.Add(fileDestination);
            }

            return filesToCopy;
        }

        private void ComputeHash(List<FileModel> files)
        {
            var hashService = new HashService();
            foreach (var file in files)
            {
                file.Hash = hashService.computeSHA256(file);
            }
        }

        private List<FileModel> WalkIntoDirectory(string path, List<FileModel>? Files = null, string? firstPath = null)
        {
            if (Files == null) Files = new List<FileModel>();
            if (firstPath == null) firstPath = path;

            string[] files = Directory.GetFiles(path);
            string[] dirs = Directory.GetDirectories(path);

            foreach (string file in files)
            {
                var newFile = new FileModel(file);
                newFile.Size = FileSize(newFile);
                newFile.RelativePath = (file.Replace(firstPath, "")).Replace(newFile.Name, "");
                Files.Add(newFile);
            }

            foreach (string dir in dirs)
            {
                WalkIntoDirectory(dir, Files, firstPath);
            }

            return Files;
        }

        private ulong FileSize(FileModel fileModel)
        {
            return (ulong)(new FileInfo(fileModel.FullPath)).Length;
        }
    }
}
