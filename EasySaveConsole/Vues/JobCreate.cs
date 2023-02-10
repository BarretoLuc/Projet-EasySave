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
            Console.WriteLine(Controller.GetTranslation("jobCreate_show_enterringJobCreationI"));
            newJob();
        }
        
        public void newJob()
        {
            Console.WriteLine(Controller.GetTranslation("jobCreate_newJob_enterName"));
            string? name = Console.ReadLine();
            Console.WriteLine(name);

            Console.WriteLine(Controller.GetTranslation("jobCreate_newJob_enterSourcePath"));
            string? sourcepath = Console.ReadLine();
            Console.WriteLine(sourcepath);

            Console.WriteLine(Controller.GetTranslation("jobCreate_newJob_enterDestPath"));
            string? destinationpath = Console.ReadLine();
            Console.WriteLine(destinationpath);

            if (name == null || sourcepath == null || destinationpath == null) return;

            Controller.CreateJob(name, sourcepath, destinationpath);
        }
        
    }
}
