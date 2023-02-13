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

        //Leave
        public void Show()
        {
            Console.Clear();
            Console.WriteLine(Controller.GetTranslation("jobCreate_show_enterringJobCreation"));
            NewJob();
        }

        public void NewJob()
        {
            Console.WriteLine(Controller.GetTranslation("jobCreate_newJob_exitMenu"));
            string? name;
            while (true)
            {
                Console.WriteLine("\n" + Controller.GetTranslation("jobCreate_newJob_enterName"));
                name = Console.ReadLine();
                if (name == "q")
                {
                    return;
                }
                if (name != null && name != "")
                {
                    break;
                }
                Console.WriteLine("\n" + Controller.GetTranslation("jobCreate_newJob_errorEnterValidName"));
            }

            Console.Clear();
            Console.WriteLine(Controller.GetTranslation("jobCreate_newJob_menuJobCreation"));
            Console.WriteLine(Controller.GetTranslation("jobCreate_newJob_exitMenu"));
            string? sourcepath;
            while (true)
            {
                Console.WriteLine("\n" + Controller.GetTranslation("jobCreate_newJob_enterSourcePath"));
                sourcepath = Console.ReadLine();
                if (sourcepath == "q")
                {
                    return;
                }
                if (sourcepath != null && sourcepath != "")
                {
                    break;
                }
                Console.WriteLine("\n" + Controller.GetTranslation("jobCreate_newJob_errorEnterValidSourcePath"));
            }

            Console.Clear();
            Console.WriteLine(Controller.GetTranslation("jobCreate_newJob_menuJobCreation"));
            Console.WriteLine(Controller.GetTranslation("jobCreate_newJob_exitMenu"));
            string? destinationpath;
            while (true)
            {
                Console.WriteLine("\n" + Controller.GetTranslation("jobCreate_newJob_enterDestPath"));
                destinationpath = Console.ReadLine();
                if (destinationpath == "q")
                {
                    return;
                }
                if (destinationpath != null && destinationpath != "")
                {
                    break;
                }
                Console.WriteLine("\n" + Controller.GetTranslation("jobCreate_newJob_errorEnterValidDestPath"));
            }

            Console.Clear();
            Console.WriteLine(Controller.GetTranslation("jobCreate_newJob_menuJobCreation"));
            Console.WriteLine(Controller.GetTranslation("jobCreate_newJob_exitMenu"));
            bool type;
            while (true)
            {
                Console.WriteLine("\n" + Controller.GetTranslation("jobCreate_newJob_enterDifferentialOrFull"));
                string? typeString = Console.ReadLine();
                if (typeString == "q")
                {
                    return;
                }
                if (typeString != null && (typeString == "d" || typeString == "f"))
                {
                    type = (typeString == "d") ? true : false;
                    break;
                }
                Console.WriteLine("\n" + Controller.GetTranslation("jobCreate_newJob_errorEnterDifferentialOrFull"));
            }

            if (name == null || sourcepath == null || destinationpath == null) return;

            Controller.CreateJob(name, sourcepath, destinationpath, type);

            Console.Clear();
        }
    }
}
