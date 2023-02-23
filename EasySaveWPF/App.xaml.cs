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
        private const string UniqueEventName = "{C81F66A9-1549-4A7A-8B81-1C290EC63C24}";
        private Mutex _mutex;

        protected override void OnStartup(StartupEventArgs e)
        {
            bool createdNew;
            _mutex = new Mutex(true, "Global\\" + UniqueEventName, out createdNew);

            if (!createdNew)
            {
                // Another instance is already running
                MessageBox.Show("Application is already running.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                _mutex.Dispose();
                Environment.Exit(0);
            }

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _mutex?.ReleaseMutex();
            _mutex?.Dispose();
            base.OnExit(e);
        }
    }
}
