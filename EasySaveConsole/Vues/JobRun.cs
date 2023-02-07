using EasySaveLib.Controllers;
using EasySaveLib.Models;
using EasySaveLib.Services;
using EasySaveLib.Vues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveConsole.Vues
{
    internal class JobRun : AbstractViewImpl<JobRunController>, IJobRun
    {


        public JobRun()
        {
        }

        public void Show(JobModel JobModel)
        {
            Console.WriteLine("Job " + JobModel.Name + " is running...");
            Controller.ExecuteOneJob(JobModel);
            Console.WriteLine("Job " + JobModel.Name + " is done.");
        }
        
        public JobModel ChooseJob(List<JobModel> jobs)
        {
            //TODO
            return jobs[0];
        }
    }
}
