using EasySaveLib.Services;
using EasySaveLib.Vues;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;
using Serilog;

namespace EasySaveLib.Controllers
{
    public class SettingsController : AbstractController<ISettings, SettingsController>
    {
        public SettingsController(ISettings View, DataStorageService StorageService) : base(View, StorageService) { }

        public override void init()
        {
            View.showMenu();
        }
        public void ChooseLangage(string lang)
        {
            Storage.ChangeLanguage(lang);
        }
        
        public void ChooseLogJson()
        {
            LogService log = new LogService();
            if (Settings.Settings.Default.logJson)
            {
                Settings.Settings.Default.logJson = false;
            }
            else
            {
                Settings.Settings.Default.logJson = true;
            }
            Settings.Settings.Default.Save();
            log.LogActualisation();
        }
        public void ChooseLogXml()
        {
            LogService log = new LogService();
            if (Settings.Settings.Default.logXml)
            {
                Settings.Settings.Default.logXml = false;
            }
            else
            {
                Settings.Settings.Default.logXml = true;
            }
            Settings.Settings.Default.Save();
            log.LogActualisation();
        }

        public void ChangeSettings(int numberJobs, string dataStorageFolder, string savePath ,string language, bool json, bool xml, string pathCryptoSoft)
        {
            if (numberJobs != 0)
                Settings.Settings.Default.numberJob = numberJobs;
            Settings.Settings.Default.numberJob = numberJobs;
            Settings.Settings.Default.dataStorageFolder = dataStorageFolder;
            Settings.Settings.Default.language = savePath;
            Settings.Settings.Default.language = language;
            Settings.Settings.Default.logJson = json;
            Settings.Settings.Default.logXml = xml;
            Settings.Settings.Default.pathCryptoSoft = pathCryptoSoft;
            Settings.Settings.Default.Save();
        }

    }
}

