
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EasySaveLib.Services
{
    internal class SoftwareRunningService
    {
        public bool IsRunningSoftware()
        {
            string[] software = GetSoftware();
            foreach (string processName in software)
            {
                if (Process.GetProcessesByName(processName).Length > 0)
                    return true;
            }
            return false;
        }

        private string[] GetSoftware()
        {   
            return Settings.Settings.Default.softwareStop.Split(';');
        }

        public void SetSoftware(string[] software)
        {
            Settings.Settings.Default.softwareStop = string.Join(";", software);
            Settings.Settings.Default.Save();
        }
    }
}
