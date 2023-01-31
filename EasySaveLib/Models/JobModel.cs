using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Models
{
    internal class JobModel
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public bool IsEncrypted { get; set; }
        public bool IsDifferential { get; set; }

        
        public JobModel(string name, string source, string destination, bool isEncrypted, bool isDifferential)
        {
            this.Name = name;
            this.Source = source;
            this.Destination = destination;
            this.IsEncrypted = isEncrypted;
            this.IsDifferential = isDifferential;
        }
    }
}
