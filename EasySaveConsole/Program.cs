using EasySaveConsole.Vues;
using EasySaveLib.Controllers;
using System;

namespace EasySaveConsole
{
    internal static class Program 
    {
        static Mutex mutex = new Mutex(true, "EasySave");
        [STAThread]
        static void Main(string[] args)
        {
            if(mutex.WaitOne(TimeSpan.Zero, true))
            {
                HomeController controller = new HomeController(new Home());
                controller.init();    
                mutex.ReleaseMutex();
            }
        }
    }
}