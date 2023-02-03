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
            Console.WriteLine("Welcome to EasySave");
            Console.WriteLine("Please select the option you want using the menu below");
            Console.WriteLine("Press 1 to access the save");
            int a = int.Parse(Console.ReadLine());
            switch (a)
            {
                case 1:
                    accesssave();
                    break;
                default:
                    Console.WriteLine("Bye");
                    break;
            }
        }

        public void accesssave() 
        {
            JobCreate JobCreateView = new JobCreate();
            JobCreateView.show();


        }
    }
}
