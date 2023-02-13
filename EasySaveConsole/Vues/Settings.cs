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
            Console.Clear();
            Console.WriteLine(Controller.GetTranslation("settings_showMenu_welcomeMessage"));
            Console.WriteLine(Controller.GetTranslation("settings_showMenu_choiceSettings"));

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine(Controller.GetTranslation("settings_showMenu_stateLanguage") + EasySaveLib.Settings.Settings.Default.language);
                    Console.WriteLine("\n" + Controller.GetTranslation("settings_showMenu_choiceLanguage"));
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
                    break;
                case "2":
                    string? a = "";
                    while (a != "q")
                    {
                        Console.Clear();
                        Console.WriteLine(Controller.GetTranslation("settings_showMenu_stateLog"));
                        Console.WriteLine(Controller.GetTranslation("settings_showMenu_stateLogJson") + EasySaveLib.Settings.Settings.Default.logJson);
                        Console.WriteLine(Controller.GetTranslation("settings_showMenu_stateLogXml") + EasySaveLib.Settings.Settings.Default.logXml);
                        Console.WriteLine("\n" + Controller.GetTranslation("settings_showMenu_choiceLogFormat"));
                        switch (a = Console.ReadLine())
                        {
                            case "1":
                                Controller.ChooseLogJson();
                                break;
                            case "2":
                                Controller.ChooseLogXml();
                                break;
                            case "q":
                                break;
                            default:
                                Console.WriteLine(Controller.GetTranslation("settings_showMenu_errorUnvalidChoice"));
                                break;
                        }
                    }
                    break;
                default:
                    Console.WriteLine(Controller.GetTranslation("settings_showMenu_errorUnvalidChoice"));
                    break;
            }
        }
    }
}
