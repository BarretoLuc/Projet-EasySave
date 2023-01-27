using EasySaveConsole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveConsole.Models
{
    internal class FileModel
    {
        private string name;
        private string path;
        private string? hash;

        public FileModel(
            string name,
            string path
        )
        {
            this.name = name;
            this.path = path;
        }

        public FileModel(
            string fullPath
        )
        {
            // Transform fullpath of file in path + name
            string[] pathSplit = fullPath.Split('\\');
            this.name = pathSplit[pathSplit.Length - 1];
            this.path = fullPath.Replace(this.name, "");
        }

        public string FullPath
        {
            get
            {
                return this.path + this.name;
            }
        }

        public string Hash
        {
            get
            {
                return (new HashService()).computeSHA256(this);
            }
        }
    }
}
