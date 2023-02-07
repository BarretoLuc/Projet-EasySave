using EasySaveConsole.Vues;
using EasySaveLib.Controllers;
using System;

namespace EasySaveConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HomeController controller = new HomeController(new Home());
            controller.init();
        }
    }
}