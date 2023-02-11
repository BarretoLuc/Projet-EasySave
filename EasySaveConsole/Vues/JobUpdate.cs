using EasySaveLib.Controllers;
using EasySaveLib.Models;
using EasySaveLib.Vues;
using System.Text;
using System.Threading.Tasks;
using EasySaveLib.Services;

namespace EasySaveConsole.Vues
{
    internal class JobUpdate : AbstractViewImpl<JobUpdateController>, IJobUpdate
    {
        public JobUpdate()
        {
        }
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("Test");
        }
        public void ShowJob(JobModel job)
        {
            Console.WriteLine("jobCreate_showJob_space");
            Console.WriteLine("jobCreate_showJob_nameJob" + job.Name);
            Console.WriteLine("jobCreate_showJob_sourcePath" + job.Source);
            Console.WriteLine("jobCreate_showJob_destPath" + job.Destination);
            Console.WriteLine("-----------------------------------");
        }
        public void ShowAll(List<JobModel> listjob)
        {
            Console.Clear();
            Console.WriteLine("You have enterred the Job update interface\n");
            Console.WriteLine("List of jobs : \n");
            foreach (JobModel job in listjob)
            {
                ShowJob(job);
            }
        }
        public int AskUpdate()
        {
            Console.WriteLine("\nQuel job veut tu modif ?\n");
            int choice = Int32.Parse(Console.ReadLine());
            return choice;
        }
        public JobModel UpdateJob(JobModel job)
        {
            string? name;
            while (true)
            {
                Console.WriteLine(Controller.GetTranslation("jobCreate_newJob_enterName"));
                name = Console.ReadLine();
                if (name != null && name != "")
                {
                    job.Name = name;
                    break;
                }
                Console.WriteLine("Please enter a name that is not null or empty.");
            }

            string? sourcepath;
            while (true)
            {
                Console.WriteLine(Controller.GetTranslation("jobCreate_newJob_enterSourcePath"));
                sourcepath = Console.ReadLine();
                if (sourcepath != null && sourcepath != "")
                {
                    job.Source = sourcepath;
                    break;
                }
                Console.WriteLine("The source path is not valid.");
            }

            string? destinationpath;
            while (true)
            {
                Console.WriteLine(Controller.GetTranslation("jobCreate_newJob_enterDestPath"));
                destinationpath = Console.ReadLine();
                if (destinationpath != null && destinationpath != "")
                {
                    job.Destination = destinationpath;
                    break;
                }
                Console.WriteLine("The destination path is not valid.");
            }

            bool type;
            while (true)
            {
                Console.WriteLine("\nPlease choose if the job should be saved in differential or in full (Enter 'd' or 'f') :");
                string? typeString = Console.ReadLine();
                if (typeString != null && (typeString == "d" || typeString == "f"))
                {
                    type = (typeString == "d") ? true : false;
                    job.IsDifferential = type;
                    break;
                }
                Console.WriteLine("This is not a valid option.");
            }

            return job;
        }

        public void Exit()
        {
            Console.WriteLine("jobView_exit_exitMenu");
            Console.Read();
        }
    }

}
