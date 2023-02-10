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

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("You have enterred the Job creation interface");
            NewJob();
        }

        public void NewJob()
        {
            string? name;
            while (true)
            {
                Console.WriteLine("\nTo begin please enter a name :");
                name = Console.ReadLine();
                if(name != null && name != "")
                {
                    break;
                }
                Console.WriteLine("Please enter a name that is not null or empty.");
            }

            string? sourcepath;
            while (true)
            {
                Console.WriteLine("\nPlease enter a source path :");
                sourcepath = Console.ReadLine();
                if (sourcepath != null && sourcepath != "")
                {
                    break;
                }
                Console.WriteLine("The source path is not valid.");
            }

            string? destinationpath;
            while (true)
            {
                Console.WriteLine("\nPlease enter a destination path :");
                destinationpath = Console.ReadLine();
                if (destinationpath != null && destinationpath != "")
                {
                    break;
                }
                Console.WriteLine("The destination path is not valid.");
            }

            bool type;
            while (true)
            {
                Console.WriteLine("\nPlease choose if the job should be saved in differential or in full (Enter 'd' or 'f') :");
                string? typeString = Console.ReadLine();
                if(typeString != null && (typeString == "d" || typeString == "f"))
                {
                    type = (typeString == "d") ? true : false;
                    break;
                }
                Console.WriteLine("This is not a valid option.");
            }

            if (name == null || sourcepath == null || destinationpath == null) return;

            Controller.CreateJob(name, sourcepath, destinationpath, type);
        }

    }
}
