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
    internal class JobView : IJobView
    {

        public JobView()
        {
        }

        public void show(JobModel job)
        {
            Console.WriteLine("Job's name :");
            Console.WriteLine(job.Name);
            Console.WriteLine("Job's source path :");
            Console.WriteLine(job.Source);
            Console.WriteLine("Job's destination path :");
            Console.WriteLine(job.Destination);
        }

        public void showall(List<JobModel> listjob)
        {
            foreach(JobModel job in listjob)
            {
                show(job);
            }
        }

    }
}
