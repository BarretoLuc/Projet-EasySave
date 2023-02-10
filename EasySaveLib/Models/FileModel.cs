using EasySaveLib.Services;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EasySaveLib.Models
{
    public class FileModel
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string? Hash { get; set; }
        public string FullPath { get => Path + Name; }
        public string RelativePath { get; set; }
        public ulong Size { get; set; }
        public long Time { get; set; }
        public string? NewName { get; set; }
        public string? NewPath { get; set; }


        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
        public State? State { get; set; }

        public FileModel() { }

        public FileModel(
            string name,
            string path
        )
        {
            this.Name = name;
            this.Path = path;
        }

        public FileModel(
            string fullPath
        )
        {
            // Transform fullpath of file in path + name
            string[] pathSplit = fullPath.Split('\\');
            this.Name = pathSplit[pathSplit.Length - 1];
            this.Path = fullPath.Replace(this.Name, "");
        }
    }
}
