using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Log4Net;
using Serilog.Events;

namespace EasySaveLib.Services
{
    public class LogService
    {
        public LogService()
        {
            LogActualisation();
        }

        ~LogService()
        {
            Log.CloseAndFlush();
        }

        public void LogActualisation()
        {
            Log.CloseAndFlush();
            if (Settings.Settings.Default.logJson)
            {
                IniLoggerJson();
            }
            if (Settings.Settings.Default.logXml)
            {
                IniLoggerXml();
            }
        }

        private void IniLoggerJson()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(new CompactJsonFormatter(), Settings.Settings.Default.dataStorageFolder + "Logs/log.json", restrictedToMinimumLevel: LogEventLevel.Information,fileSizeLimitBytes: 20000, rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
                .CreateLogger();
        }

        private void IniLoggerXml()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(new Log4NetTextFormatter(), Settings.Settings.Default.dataStorageFolder + "Logs/log.xml", restrictedToMinimumLevel: LogEventLevel.Information, fileSizeLimitBytes: 20000, rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
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
        public static void AddLogActionJob(string name, string fileSource, string nameFileTarget, string destPath, ulong fileSize, int fileTransferTime)
        {
            Log.Information("{Name},{FileSource},{FileTarget},{DestPath},{FileSize},{FileTransferTime}", name, fileSource, nameFileTarget, destPath,fileSize,fileTransferTime);
        }
    }
}