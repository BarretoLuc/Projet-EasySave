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
            List<FileModel> AllFilesReOrder = new List<FileModel>();
            string fileExtension;

            int count = AllFiles.Count;
            for (int i = 0 ; i < count; i++)
            {
                foreach (string extensions in allowedExtensions)
                {
                    if (AllFiles[i].Name.Contains(extensions))
                    {
                        AllFilesReOrder.Add(AllFiles[i]);
                        AllFiles.Remove(AllFiles[i]);
                        count -= 1;
                        i--;
                    }
                }
            }

            foreach (var item in AllFiles)
            {
                AllFilesReOrder.Add(item);
            }

            return AllFilesReOrder;
        }
        
        
    }
}
