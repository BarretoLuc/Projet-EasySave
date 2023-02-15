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

namespace EasySaveWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IAbstractView<HomeController>, IHome
    {
        public HomeController Controller { get; set; }
        
        public MainWindow()
        {
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
            Main.Content = new JobCreatePage();
        }

        private void JobRemoveClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new JobRemovePage();
        }
        
        private void SettingsClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new SettingsPage();
        }

        private void JobRunClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new JobRunPage();
        }

        private void JobUpdateClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new JobUpdatePage();
        }
    }
}
