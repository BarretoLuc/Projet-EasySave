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
    }
    
}

