using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Models
{
    public class JobModel
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public bool IsEncrypted { get; set; }
        public bool IsDifferential { get; set; }
        public List<FileModel>? AllFiles { get; set; }


        public JobModel(
            string name,
            string source,
            string destination,
            bool IsDifferential = false,
            bool IsEncrypted = false
        )
        {
            Name = name;
            Source = source;
            Destination = destination;
            this.IsDifferential = IsDifferential;
            this.IsEncrypted = IsEncrypted;
        }

        public void ConvertPath()
        { 
            if (!Source.EndsWith(@"\"))
                Source = Source + @"\";

            if (!Destination.EndsWith(@"\"))
                Destination = Destination + @"\";
        }

    }
}
