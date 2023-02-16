using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EasySaveLib.Controllers;
using EasySaveLib.Vues;
using EasySaveLib.Models;
using System.Threading;
using System.Diagnostics.Metrics;

namespace EasySaveWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IAbstractView<HomeController>, IHome
    {
        public  HomeController Controller { get; set; }
        
        static Mutex mutex = new Mutex(true, "EasySave");
        public MainWindow()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
            HomeController controller = new HomeController(this);
            controller.init();
            mutex.ReleaseMutex();
            }
        }
        
        public void showMenu()
        {
            InitializeComponent();
        }

        private void JobViewClick(object sender, RoutedEventArgs e)
        {
            JobViewPage view = new JobViewPage();
            Controller.ShowJobViews(view);
            Main.Content = view;
        }

        private void JobCreateClick(object sender, RoutedEventArgs e)
        {
            JobCreatePage view = new JobCreatePage();
            Controller.AccessSave(view);
            Main.Content = view;
        }

        private void JobRemoveClick(object sender, RoutedEventArgs e)
        {
            JobRemovePage view = new JobRemovePage();
            Controller.ShowJobRemove(view);
            Main.Content = view;
        }
        
        private void SettingsClick(object sender, RoutedEventArgs e)
        {
            SettingsPage view = new SettingsPage();
            Controller.ShowSettings(view);
            Main.Content = view;
        }

        private void JobRunClick(object sender, RoutedEventArgs e)
        {
            JobRunPage view = new JobRunPage();
            Controller.ShowJobRun(view);
            Main.Content = view;
        }

        private void JobUpdateClick(object sender, RoutedEventArgs e)
        {
            JobUpdatePage view = new JobUpdatePage();
            Controller.ShowJobUpdate(view);
            Main.Content = view;
        }
    }
}
