using EasySaveLib.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace EasySaveWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static Mutex mutex = new Mutex(true, "EasySave");
        App()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                HomeController controller = new HomeController(new MainWindow());
                controller.init();
                mutex.ReleaseMutex();
            }
        }
    }
}
