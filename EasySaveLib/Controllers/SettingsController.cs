using EasySaveLib.Services;
using EasySaveLib.Vues;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Globalization;
using System.ComponentModel;
using System.Reflection;

namespace EasySaveLib.Controllers
{
    public class SettingsController : AbstractController<ISettings, SettingsController>
    {
        private ResourceManager rm;
        public SettingsController(ISettings View) : base(View)
        {
        }

        public override void init()
        {
            View.showMenu();
        }
        public void ChooseLangage(int choice)
        {
            if (choice== 1)
            {
                rm = new ResourceManager("EasySaveConsole.Ressources.Languages.english", Assembly.GetExecutingAssembly());
            } else
            {
                rm = new ResourceManager("EasySaveConsole.Ressources.Languages.francais", Assembly.GetExecutingAssembly());
            }
        }
    }
    
}

