using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveLib.Vues;

namespace EasySaveConsole.Vues
{
    internal class JobCreate : IJobCreate
    {
        public void show() 
        {
            Console.WriteLine("You have enterred the Job creation interface");
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
        }
    }
}
