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
            int choice = Convert.ToInt32(Console.ReadLine());
            Controller.ChooseLangage(choice);
        }
    }
}
