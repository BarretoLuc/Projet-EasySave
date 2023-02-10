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
            Console.WriteLine("Job's name : " + job.Name);
            Console.WriteLine("Job's source path :" + job.Source);
            Console.WriteLine("Job's destination path : " + job.Destination);
            Console.WriteLine("Job's type : " + (job.IsDifferential ? "Differential" : "Full"));
        }

        public void ShowAll(List<JobModel> listjob)
        {
            foreach(JobModel job in listjob)
            {
                Show(job);
            }
        }

        public void Exit()
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Press any key to exit the view menu.");
            Console.Read();
        }

    }
}
