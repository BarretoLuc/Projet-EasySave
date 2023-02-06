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
        
        public JobModel(string name, string source, string destination, bool isEncrypted, bool isDifferential)
        {
            Name = name;
            Source = source;
            Destination = destination;
            IsEncrypted = isEncrypted;
            IsDifferential = isDifferential;
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
