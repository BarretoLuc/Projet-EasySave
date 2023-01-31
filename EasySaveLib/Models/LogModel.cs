using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EasySaveLib.Models
{
    internal class LogModel
    {
        public string Name { get; set; }
        public string Timestamp { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int Size { get; set; }
        public float TransfertTime { get; set; }
        
        public LogModel(string name, string timestamp, string source, string destination, int size, float transfertTime)
        {
            Name = name;
            Timestamp = timestamp;
            Source = source;
            Destination = destination;
            Size = size;
            TransfertTime = transfertTime;
        }
    }
}
