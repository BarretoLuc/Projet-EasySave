using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Models
{
    internal class JobModel
    {
        private string name;
        private string source;
        private string destination;
        private bool isEncrypted;
        private bool isDifferential;

        public JobModel(string name, string source, string destination, bool isEncrypted, bool isDifferential)
        {
            this.name = name;
            this.source = source;
            this.destination = destination;
            this.isEncrypted = isEncrypted;
            this.isDifferential = isDifferential;
        }

        public string Name { get => name; set => name = value; }
        public string Source { get => source; set => source = value; }
        public string Destination { get => destination; set => destination = value; }
        public bool IsEncrypted { get => isEncrypted; set => isEncrypted = value; }
        public bool IsDifferential { get => isDifferential; set => isDifferential = value; }
    }
}
