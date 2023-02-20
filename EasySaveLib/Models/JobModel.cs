using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StateFile = EasySaveLib.Models.State;

namespace EasySaveLib.Models
{
    public class JobModel
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public bool IsEncrypted { get; set; }
        public bool IsDifferential { get; set; }
        
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
        public JobStatsEnum? State { get; set; }
        public List<FileModel>? AllFiles { get; set; }
        public int NumberOfFiles { get => AllFiles?.Count ?? 0; }
        public int NumberOfFilesRemaining { get => AllFiles?.Where(file => file.State != StateFile.Finished).Count() ?? 0; }
        public int NumberOfFilesFinished { get => AllFiles?.Where(file => file.State == StateFile.Finished).Count() ?? 0; }

        public JobModel(
            string name,
            string source,
            string destination,
            bool IsDifferential = false,
            bool IsEncrypted = false,
            JobStatsEnum? State = null
        )
        {
            Name = name;
            Source = source;
            Destination = destination;
            this.IsDifferential = IsDifferential;
            this.IsEncrypted = IsEncrypted;
            this.State = State ?? JobStatsEnum.NotStarted;
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
