using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySave.Vues;

namespace EasySaveConsole.Vues
{
    internal class Home : IHome
    {
        public void show()
        {
            Console.WriteLine("Welcome to EasySave");
        }
    }
}
