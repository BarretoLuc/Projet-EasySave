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
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(Controller.GetTranslation("jobView_show_nameJob") + job.Name);
            Console.WriteLine(Controller.GetTranslation("jobView_show_sourcePath") + job.Source);
            Console.WriteLine(Controller.GetTranslation("jobView_show_destPath") + job.Destination);
        }

        public void ShowAll(List<JobModel> listjob)
        {
            Console.Clear();
            Console.WriteLine(Controller.GetTranslation("jobView_showAll_enterringJobView") + "\n");
            Console.WriteLine(Controller.GetTranslation("jobView_showAll_listJob") + "\n");
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
