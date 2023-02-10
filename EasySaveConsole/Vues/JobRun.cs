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

        public void ShowStart(JobModel JobModel)
        {
            Console.WriteLine(Controller.GetTranslation("jobRun_showEnd_job") + JobModel.Name + Controller.GetTranslation("jobRun_showEnd_isRunning"))
        }

        public void ShowEnd(JobModel JobModel)
        {
            Console.WriteLine(Controller.GetTranslation("jobCreate_newJob_enterName")) + ();
        }

            public JobModel ChooseJob(List<JobModel> jobs)
        {
            //TODO
            return jobs[0];
        }
    }
}
