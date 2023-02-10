using EasySaveConsole.Vues;
using EasySaveLib.Controllers;
using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Globalization;
using System.ComponentModel;

namespace EasySaveConsole
{
    internal static class Program 
    {
        static ResourceManager rm;
        static CultureInfo cult;

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

        static void switch_language()
        {
            cult = CultureInfo.CreateSpecificCulture("en");
            rm = new ResourceManager("EasySaveConsole.Ressources.Languages.Res", Assembly.GetExecutingAssembly());
        }
    }
}