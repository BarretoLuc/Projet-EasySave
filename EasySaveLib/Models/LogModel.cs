using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Models
{
    internal class LogModel
    {
        private string timestamp;
        private string name;
        private string source;
        private string destination;
        private float size;
        private int transfertTime;

        public LogModel(string timestamp, string name, string source, string destination, float size, int transfertTime)
        {
            this.timestamp = timestamp;
            this.name = name;
            this.source = source;
            this.destination = destination;
            this.size = size;
            this.transfertTime = transfertTime;
        }

        public string Timestamp { get => timestamp; set => timestamp = value; }
        public string Name { get => name; set => name = value; }
        public string Source { get => source; set => source = value; }
        public string Destination { get => destination; set => destination = value; }
        public float Size { get => size; set => size = value; }
        public int TransfertTime { get => transfertTime; set => transfertTime = value; }
    }
}
