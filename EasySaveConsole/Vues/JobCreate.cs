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
    internal class JobCreate : AbstractViewImpl<JobCreateController>, IJobCreate
    {

        public JobCreate()
        {
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

            bool type;
            while (true)
            {
                Console.WriteLine("Please choose if the job should be saved in differential or in full (Enter 'd' or 'f') :");
                string? typeString = Console.ReadLine();
                Console.WriteLine(typeString);
                if(typeString == "d" || typeString == "f")
                {
                    type = (typeString == "d") ? true : false;
                    break;
                }
                Console.WriteLine("Please enter a valid option.");
            }

            if (name == null || sourcepath == null || destinationpath == null) return;

            Controller.CreateJob(name, sourcepath, destinationpath, type);
        }

    }
}
