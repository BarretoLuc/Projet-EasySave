using EasySaveLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Services
{
    public class PriorityExtensionsServices
    {
        public PriorityExtensionsServices()
        {
        }
        private string[] GetExtensions()
        {
            return Settings.Settings.Default.PriorityExtensions.Split(';');
        }

        private void SetExtensions(string[] extensions)
        {
            Settings.Settings.Default.PriorityExtensions = string.Join(";", extensions);
            Settings.Settings.Default.Save();
        }
        
        public List<FileModel> SortExtensions(List<FileModel> AllFiles)
        {
            string[] allowedExtensions = GetExtensions();
            var AllFilesReOrder = new List<FileModel>();
            var OtherFiles = new List<FileModel>();
            string fileExtension;
            foreach (var files in AllFiles)
            {
                foreach (var extensions in allowedExtensions)
                {
                    fileExtension = Path.GetExtension(files.Name);
                    if (fileExtension == extensions)
                        AllFilesReOrder.Add(files);
                    else
                        OtherFiles.Add(files);
                }
            }

            foreach (var item in OtherFiles)
            {
                AllFilesReOrder.Add(item);
            }


            return AllFilesReOrder;
        }
        
        
    }
}
