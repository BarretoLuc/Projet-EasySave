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
        public ulong Timestamp { get; set; }
        public bool Status { get; set; }
        public uint TotalFileNumber { get; set; }
        public ulong TotalFileSize { get; set; }
        public uint RemainingFileNumber { get; set; }
        public ulong RemainingFileSize { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        
        public StatusJobModel(string name, ulong timestamp, bool status, int totalFileNumber, ulong totalFileSize, int remainingFileNumber, ulong remainingFileSize, string source, string destination)
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
