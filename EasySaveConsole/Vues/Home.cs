using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveLib.Controllers;
using EasySaveLib.Vues;

namespace EasySaveConsole.Vues
{
    internal class Home : IHome
    {
        private HomeController HomeController { get; set; }
        
        public Home() {
            HomeController = new HomeController();
        }
        
        public void show()
        {
            string a = "";
            Console.WriteLine("Welcome to EasySave");
            while (a != "q")
            {   
                Console.WriteLine("Please select the option you want using the menu below");
                Console.WriteLine("\n\n   'jc' => to create a new job");
                Console.WriteLine("   'je' => to execute a job");
                Console.WriteLine("\n\nPress q to quit program\n");
                a = Console.ReadLine() ?? "";
                switch (a)
                {
                    case "jc":
                        AccessSave();
                        break;
                    case "je":
                        ShowJobRun();
                        break;
                    case "q":
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }

        public void AccessSave() 
        {
            JobCreate JobCreateView = new JobCreate(HomeController.Storage);
            JobCreateView.show();
        }

        private void ShowJobRun()
        {
            JobRun JobRun = new JobRun(HomeController.Storage, HomeController.Storage.JobList[0]);
            JobRun.Show();
            Console.ReadKey(true);
        }
    }
}
