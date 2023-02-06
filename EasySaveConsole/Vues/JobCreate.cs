using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveLib.Controllers;
using EasySaveLib.Services;
using EasySaveLib.Vues;

namespace EasySaveConsole.Vues
{
    internal class JobCreate : IJobCreate
    {
        public DataStorageService Storage { get; }
        public JobController JobController { get; }

        public JobCreate(DataStorageService StorageService)
        {
            this.Storage = StorageService;
            this.JobController = new JobController(Storage);
        }
        
        public void show() 
        {
            Console.WriteLine("\nYou have enterred the Job creation interface\n");
            newJob();
        }
        
        public void newJob()
        {
            Console.WriteLine("To begin please enter a name :");
            string? name = Console.ReadLine();
            Console.WriteLine(name);

            Console.WriteLine("Please enter a source path :");
            string? sourcepath = Console.ReadLine();
            Console.WriteLine(sourcepath);

            Console.WriteLine("Please enter a destination path :");
            string? destinationpath = Console.ReadLine();
            Console.WriteLine(destinationpath);

            if (name == null || sourcepath == null || destinationpath == null) return;

            this.JobController.CreateJob(name, sourcepath, destinationpath);
        }
    }
}
