using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySave.Controllers;
using EasySave.Vues;

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
        }
    }
}
