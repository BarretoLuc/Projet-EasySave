using EasySaveLib.Controllers;
using EasySaveLib.Models;
using EasySaveLib.Vues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveConsole.Vues
{
    internal class JobView : AbstractViewImpl<JobViewController>, IJobView
    {

        public JobView()
        {
        }

        public void Show(JobModel job)
        {
            Console.WriteLine(Controller.GetTranslation("jobView_show_space"));
            Console.WriteLine(Controller.GetTranslation("jobView_show_nameJob") + job.Name);
            Console.WriteLine(Controller.GetTranslation("jobView_show_sourcePath") + job.Source);
            Console.WriteLine(Controller.GetTranslation("jobView_show_destPath") + job.Destination);
        }

        public void ShowAll(List<JobModel> listjob)
        {
            Console.Clear();
            Console.WriteLine("You have enterred the Job creation interface\n");
            Console.WriteLine("List of jobs : \n");
            foreach (JobModel job in listjob)
            {
                Show(job);
            }
        }

        public void Exit()
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(Controller.GetTranslation("jobView_exit_exitMenu"));
            Console.Read();
        }

    }
}
