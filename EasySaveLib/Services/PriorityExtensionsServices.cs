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
            foreach (var extensions in allowedExtensions)
            {
                AllFiles.OrderBy(p => Path.GetExtension(p.Name));
                //AllFiles.Sort
            }

            return AllFiles;
        }
        
        
    }
}
