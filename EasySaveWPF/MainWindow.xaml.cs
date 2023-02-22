﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using EasySaveLib.Controllers;
using EasySaveLib.Vues;
using EasySaveLib.Models;
using System.Threading;
using EasySaveWPF.ModelViews;

namespace EasySaveWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IAbstractView<HomeController>, IHome
    {
        static Mutex mutex = new Mutex(true, "EasySave");
        public HomeController Controller { get; set; }

        private ViewModel ViewModel;
        private RunModel RunModel;
        private UpdateModel UpdateModel;
        private RemoveModel RemoveModel;
        public SettingsWindow Settings;
        private JobCreate CreateView;

        private List<JobModel> ListJob;

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
            ViewModel = new ViewModel(this);
            Controller.ShowJobViews(ViewModel);
            RunModel = new RunModel(this);
            Controller.ShowJobRun(RunModel);
            UpdateModel = new UpdateModel(this);
            Controller.ShowJobUpdate(UpdateModel);
            RemoveModel = new RemoveModel(this);
            Controller.ShowJobRemove(RemoveModel);
        }
        public void ShowAllJob(List<JobModel> listJob)
        {
            ListJob = listJob;
            dgJob.ItemsSource = ListJob;
        }

        public int ChooseJobRemove(int listJobLength)
        {
            if (dgJob.SelectedItems.Count <= 0)
                return 0;

            else if (dgJob.SelectedItems.Count == 1)
            {
                if (dgJob.SelectedIndex != -1)
                {
                    int id = dgJob.SelectedIndex;
                    return id + 1;
                }
            }
            return 0;
        }

        public void Progress()
        {
            //pbExecute.Value++;
        }

        private void JobSelected(object sender, SelectionChangedEventArgs e)
        {
            if (dgJob.SelectedIndex != -1)
                dgFile.ItemsSource = ListJob[dgJob.SelectedIndex].AllFiles;
        }

        private void StopClick(object sender, RoutedEventArgs e)
        {
            if (dgJob.SelectedItems.Count <= 0)
                return;

            if (dgJob.SelectedItems.Count == 1)
                RunModel.Controller.PauseOneJob(ListJob[dgJob.SelectedIndex]);
            else if (dgJob.SelectedItems.Count > 1)
            {
                foreach (JobModel item in dgJob.SelectedItems)
                {
                    RunModel.Controller.PauseOneJob(item);
                }
            }
        }

        private void StartClick(object sender, RoutedEventArgs e)
        {
            if (dgJob.SelectedItems.Count <= 0)
                return;

            if (dgJob.SelectedItems.Count == 1)
                RunModel.Controller.ExecuteOneJob(ListJob[dgJob.SelectedIndex]);
            else if (dgJob.SelectedItems.Count > 1)
            {
                foreach (JobModel item in dgJob.SelectedItems)
                {
                    RunModel.Controller.ExecuteOneJob(item);
                }
            }
        }

        private void SettingsClick(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            Settings = new SettingsWindow(this);
            Controller.ShowSettings(Settings);
            Settings.Show();
        }

        private void SaveJobClick(object sender, RoutedEventArgs e)
        {
            UpdateModel.Controller.SaveJob();
        }

        private void RemoveClick(object sender, RoutedEventArgs e)
        {
            RemoveModel.Controller.RemoveSelection();
            dgJob.ItemsSource = null;
            dgJob.ItemsSource = ListJob;
        }

        private void ClosingClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UpdateModel.Controller.SaveJob();
        }

        private void CreateClick(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            CreateView = new JobCreate(this);
            Controller.AccessSave(CreateView);
        }
    }
}
