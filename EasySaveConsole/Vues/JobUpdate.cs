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
        }
        public void ShowJob(JobModel job)
        {
            Console.WriteLine(Controller.GetTranslation("jobUpdate_showJob_nameJob") + job.Name);
            Console.WriteLine(Controller.GetTranslation("jobUpdate_showJob_sourcePath") + job.Source);
            Console.WriteLine(Controller.GetTranslation("jobUpdate_showJob_destPath") + job.Destination);
            Console.WriteLine("-----------------------------------");
        }
        public void ShowAll(List<JobModel> listjob)
        {
            Console.Clear();
            Console.WriteLine(Controller.GetTranslation("jobUpdate_ShowAll_EnterMessage") + "\n");
            Console.WriteLine(Controller.GetTranslation("jobUpdate_ShowAll_ListOfJobs") + "\n");
            foreach (JobModel job in listjob)
            {
                ShowJob(job);
            }
        }
        public int AskUpdate(int listJobLength)
        {
            Console.WriteLine(Controller.GetTranslation("jobUpdate_AskUpdate_WichJob"));
            string? choice = "";
            while(choice != "q")
            {
                choice = Console.ReadLine();
                if (Int32.TryParse(choice, out int choiceInt))
                    if(choiceInt <= listJobLength)
                        return choiceInt;
                if (choice != "q")
                    Console.WriteLine(Controller.GetTranslation("JobUpdate_ErrorMessage_Choice"));
            }
            return 0;
        }
        public JobModel UpdateJob(JobModel job)
        {
            Console.Clear();
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
                Console.WriteLine(Controller.GetTranslation("jobUpdate_updateJob_errorNameNotNullOrEmpty"));
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
                Console.WriteLine(Controller.GetTranslation("jobUpdate_updateJob_errorSourcePathUnvalid"));
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
                Console.WriteLine(Controller.GetTranslation("jobUpdate_updateJob_errorDestPathUnvalid"));
            }

            bool type;
            while (true)
            {
                Console.WriteLine(Controller.GetTranslation("\njobUpdate_updateJob_choiceDiffOrFull"));
                string? typeString = Console.ReadLine();
                if (typeString != null && (typeString == "d" || typeString == "f"))
                {
                    type = (typeString == "d") ? true : false;
                    job.IsDifferential = type;
                    break;
                }
                Console.WriteLine(Controller.GetTranslation("jobUpdate_updateJob_errorInvalidOption"));
            }

            return job;
        }

        public void Exit()
        {
            Console.WriteLine(Controller.GetTranslation("jobUpdate_exit_exitMenu"));
            Console.Read();
        }
    }

}
