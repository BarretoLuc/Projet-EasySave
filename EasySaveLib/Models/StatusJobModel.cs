using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Models
{
    internal class StatusJobModel
    {
        public string Name { get; set; }
        public string Timestamp { get; set; }
        public bool Status { get; set; }
        public int TotalFileNumber { get; set; }
        public int TotalFileSize { get; set; }
        public int RemainingFileNumber { get; set; }
        public int RemainingFileSize { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        
        public StatusJobModel(string name, string timestamp, bool status, int totalFileNumber, int totalFileSize, int remainingFileNumber, int remainingFileSize, string source, string destination)
        {
            Name = name;
            Timestamp = timestamp;
            Status = status;
            TotalFileNumber = totalFileNumber;
            TotalFileSize = totalFileSize;
            RemainingFileNumber = remainingFileNumber;
            RemainingFileSize = remainingFileSize;
            Source = source;
            Destination = destination;
        }
    }
}
