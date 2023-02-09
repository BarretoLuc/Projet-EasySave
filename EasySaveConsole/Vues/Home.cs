using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveLib.Controllers;
using EasySaveLib.Vues;

namespace EasySaveConsole.Vues
{
    internal class Home : AbstractViewImpl<HomeController>, IHome
    {

        public Home()
        {
        }

        public void showMenu()
        {
            string a = "";
            Console.WriteLine("Welcome to EasySave");
            while (a != "q")
            {
                Console.WriteLine("Please select the option you want using the menu below");
                Console.WriteLine("\n\n   'jc' => to create a new job");
                Console.WriteLine("   'je' => to execute a job");
                Console.WriteLine("   'jv' => to see all job");
                Console.WriteLine("\n\nPress q to quit program\n");
                a = Console.ReadLine() ?? "";
                switch (a)
                {
                    case "jc":
                        Controller.AccessSave(new JobCreate());
                        break;
                    case "je":
                        Controller.ShowJobRun(new JobRun());
                        break;
                    case "jv":
                        Controller.ShowJobViews(new JobView());
                        break;
                    case "q":
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }
        
    }
}
