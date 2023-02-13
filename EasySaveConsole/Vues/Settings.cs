using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveLib.Controllers;
using EasySaveLib.Vues;

namespace EasySaveConsole.Vues
{
    internal class Settings : AbstractViewImpl<SettingsController>, ISettings
    {
        public Settings() 
        {
        }

        public void showMenu()
        {
            Console.WriteLine(Controller.GetTranslation("\nsettings_showMenu_welcomeMessage\n"));
            Console.WriteLine(Controller.GetTranslation("settings_showMenu_choiceLanguage"));

            switch (Console.ReadLine())
            {
                case "1":
                    Controller.ChooseLangage("Francais");
                    break;
                case "2":
                    Controller.ChooseLangage("English");
                    break;
                default:
                    Console.WriteLine(Controller.GetTranslation("settings_showMenu_errorUnvalidChoice"));
                    break;
            }
        }
    }
}
