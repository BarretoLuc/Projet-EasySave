using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Events;
using EasySaveLib.Models;
using Serilog.Formatting.Json;
using Serilog.Sinks.File;
using EasySaveLib.Services;

namespace EasySaveLib.Services
{
    public class LogService
    {
        public LogService()
        {
            IniLogger();
        }

        ~LogService()
        {
            Log.CloseAndFlush();
        }

        /// <summary>
        ///     Initialize the logger.
        /// </summary>
        private void IniLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(new CompactJsonFormatter(), "Logs/information.json", restrictedToMinimumLevel: LogEventLevel.Information,fileSizeLimitBytes: 20000, rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
                .CreateLogger();
        }

        /// <summary>
        ///     Add a log of an action of a backup job.
        /// </summary>
        /// <param name="name">Name of the backup job.</param>
        /// <param name="fileSource">Full address of the Source file (UNC format).</param>
        /// <param name="nameFileTarget">Destination file name (UNC format).</param>
        /// <param name="destPath">Full address of the destination file (UNC format).</param>
        /// <param name="fileSize">File size.</param>
        /// <param name="fileTransferTime">File transfer time in ms (negative if error).</param>
        public static void AddLogActionJob(string name, string fileSource, string nameFileTarget, string destPath, int fileSize, int fileTransferTime)
        {
            Log.Information("{Name},{FileSource},{FileTarget},{DestPath},{FileSize},{FileTransferTime}", name, fileSource, nameFileTarget, destPath,fileSize,fileTransferTime);
        }
    }
}
//new LogService(); POUR INITIALISER LE LOGGEUR
//LogService.AddLog("job1", "c:\\tmp\\test", "valouuu", "c:\\tmp\\test2", "10000", "100"); POUR AJOUTER UN LOG