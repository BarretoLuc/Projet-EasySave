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
            Console.WriteLine("\nYou have enterred the Settings interface\n");
            Console.WriteLine("Choose a langage : 1. French, 2. English");

            switch (Console.ReadLine())
            {
                case "1":
                    Controller.ChooseLangage("francais");
                    break;
                case "2":
                    Controller.ChooseLangage("english");
                    break;
                default:
                    Console.WriteLine("Please enter a valid choice");
                    break;
            }
        }
    }
}
